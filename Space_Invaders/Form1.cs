using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        bool right, left, isSdown, isCtrldown, isYdown;
        bool direction=false;
        bool isPaused = false;
        int score = 0;
        int HPs = 3;
        bool gameOver = false;
        bool isBoss1 = false;
        bool isBoss2 = false;
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();

        hero Hero;

        public void spawnHero()
        {
            Hero = new hero(this.Width, this.Height);
            this.Controls.Add(Hero);
            Hero.BringToFront();
            Hero.onGetHP += Hero_onGetHP;
            Hero.onUpgrade += Hero_onUpgrade;
            Hero.onLoseHP += Hero_onLoseHP;
            Hero.onFireMissiles += Hero_onFireMissiles;
        }

        

        bool isReady = true;
        bool isDropped = false;
        int difficulty = 0;

        boss1 boss1;
        boss2 boss2;
        
        List<enemy> enemies=new List<enemy>() ;
        List<bullet> bullets = new List<bullet>();
        List<bonus> bons = new List<bonus>();
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (right && Hero.Right < Field.Width) Hero.Left += Hero.speed;
            if (left && Hero.Left > 0) Hero.Left -= Hero.speed;

            if(isSdown && isCtrldown)           //сериализация
            {
                level lev = new level(score,difficulty,HPs);
                FileStream stream = File.Create("level.bin");
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream,lev);
                stream.Close();
            }

            if (isCtrldown && isYdown)             //десериализация
            {
                level lev;
                FileStream stream = File.Open("level.bin", FileMode.Open);
                var deserializer = new BinaryFormatter();
                lev = deserializer.Deserialize(stream) as level;
                stream.Close();
                score = lev.score;
                labelScore.Text = "SCORE : " + score;
                difficulty = lev.difficulty - 1;
                HPs = lev.HPs;
                switch (HPs)
                {
                    case 3:
                        hp2.Visible = true;
                        hp1.Visible = true;
                        hp0.Visible = true;
                        break;
                    case 2:
                        hp2.Visible = false;
                        hp1.Visible = true;
                        hp0.Visible = true;
                        break;
                    case 1:
                        hp2.Visible = false;
                        hp1.Visible = false;
                        hp0.Visible = true;
                        break;
                    case 0:
                        hp2.Visible = false;
                        hp1.Visible = false;
                        hp0.Visible = false;
                        break;
                }
                foreach(enemy en in enemies)
                    this.Controls.Remove(en);
                enemies.Clear();
                if (isBoss1)
                {
                    this.Controls.Remove(boss1);
                    isBoss1 = false;
                    timer2.Enabled = false;
                }
                if (isBoss2)
                {
                    this.Controls.Remove(boss2);
                    isBoss2 = false;
                    timer3.Enabled = false;
                }
                isReady = true;                 //запуск уровня заново
            }
            if (!isReady && rand.Next(1000)==0)
            {
                int x = rand.Next(600);
                int eff = rand.Next(4);
                bonus bon = new bonus(x, 30, 3, eff);
                
                bon.onChange += Bon_onChange;
                bons.Add(bon);
                this.Controls.Add(bon);
                bon.BringToFront();
                isDropped = true;
            }

            foreach(bullet y in bullets.ToArray())
            {
                    if (y.OwnBullet) y.Top -= y.Speed;
                    else y.Top += y.Speed;
                    if(((PictureBox)y).Top < 0 || ((PictureBox)y).Top > this.Height-60)
                    {
                        bullets.Remove(y);
                        this.Controls.Remove(y);
                    }

                    if(!y.OwnBullet && y.Bounds.IntersectsWith(Hero.Bounds))
                    {
                    bullets.Remove(y);
                    this.Controls.Remove(y);
                    HPs--;
                    System.Threading.Thread.Sleep(50);
                    switch(HPs)
                    {
                        case 3:
                            hp2.Visible = true;
                            hp1.Visible = true;
                            hp0.Visible = true;
                            break;
                        case 2:
                            hp2.Visible = false;
                            hp1.Visible = true;
                            hp0.Visible = true;
                            break;
                        case 1:
                            hp2.Visible = false;
                            hp1.Visible = false;
                            hp0.Visible = true;
                            break;
                        case 0:
                            hp2.Visible = false;
                            hp1.Visible = false;
                            hp0.Visible = false;
                            break;
                    }
                    System.Threading.Thread.Sleep(50);
                }
            }
            //int check = 0;

            if(isDropped)
            {
                foreach (bonus bon in bons.ToArray())
                {
                    bon.Top += bon.speed;
                    bon.H = bon.Top;
                }
            }

            if(isBoss1)
            {
                boss1.dance(rand, boss1.bossDir, difficulty, boss1.Left, bullets, this);
                if (boss1.Left > this.Width - 150 || boss1.Left < 0)
                {
                    boss1.bossDir = !boss1.bossDir;
                }
            }

            if (isBoss2)
            {
                boss2.dance(rand, boss2.bossDir, difficulty, boss2.Left, bullets, this);
                if (boss2.Left > this.Width - 150 || boss2.Left < 0)
                {
                    boss2.bossDir = !boss2.bossDir;
                }
            }

            foreach (enemy x in enemies)
            {
                x.dance(rand, direction, difficulty, x.Left, bullets, this);

                
                    if (x.Left > this.Width - 40 || x.Left < 0)
                    {
                        direction = !direction;
                        foreach (Control y in this.Controls)
                        {
                            if (y.Tag == "enemy")
                            {
                                y.Top += 40;
                            }
                        }
                        break;             
                    }

                if (x.Top > this.Height-90) gameOver = true;
            }

            if (enemies.Count == 0 && !isBoss1 && !isBoss2)
            {
                isReady = true;             
            }

            if(isReady)
            {
                labelToStart.Text = "Press 'z' to start lvl" + (difficulty+1);
                labelToStart.Visible = true;
            }

            foreach (enemy i in enemies.ToArray())              //обработка попаданий по врагам
            {
                foreach(bullet j in bullets.ToArray())
                {
                            if (i.Bounds.IntersectsWith(j.Bounds) && j.OwnBullet)
                            {
                                i.healthPoints--;
                                bullets.Remove(j);
                                this.Controls.Remove(j);
                            }

                            if (i.healthPoints == 0)
                            {
                                score += 1;
                                labelScore.Text = "SCORE : " + score;
                                enemies.Remove(i);
                                this.Controls.Remove(i);
                                break;
                            }                          
                }
            }

            if (isBoss1)                                     //обработка попаданий по боссу1
            {
                foreach (bullet j in bullets.ToArray())
                {              
                    if (boss1.Bounds.IntersectsWith(j.Bounds) && j.OwnBullet)
                    {
                        boss1.healthPoints--;
                        bullets.Remove(j);
                        this.Controls.Remove(j);
                    }
                    if (boss1.healthPoints == 0)
                    {
                        score += 50;
                        labelScore.Text = "SCORE : " + score;
                        this.Controls.Remove(boss1);
                        isBoss1 = false;
                        timer2.Enabled = false;
                        break;
                    }
                }
            }

            if (isBoss2)                                     //обработка попаданий по боссу2
            {
                foreach (bullet j in bullets.ToArray())
                {
                    if (boss2.Bounds.IntersectsWith(j.Bounds) && j.OwnBullet)
                    {
                        boss2.healthPoints--;
                        bullets.Remove(j);
                        this.Controls.Remove(j);
                    }
                    if (boss2.healthPoints == 0)
                    {
                        score += 50;
                        labelScore.Text = "SCORE : " + score;
                        this.Controls.Remove(boss2);
                        isBoss2 = false;
                        timer3.Enabled = false;
                        break;
                    }
                }
            }


            if (gameOver || HPs==0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                gOver.Enabled = true;
                gOver.Visible = true;
                gOver.Dock = DockStyle.Fill;
                gOver.BackColor = Color.Transparent;
                labelScore.BringToFront();
                lvlabel.BringToFront();
                //gOver.BringToFront();
            }
        }


        public bool isLaunched = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameOver && !(HPs==0))
            {
                if (e.KeyCode == Keys.S) isSdown = true;
                if (e.KeyCode == Keys.ControlKey) isCtrldown = true;
                if (e.KeyCode == Keys.Y) isYdown = true;
                if (!isPaused)
                {
                    if (e.KeyCode == Keys.Right) right = true;
                    if (e.KeyCode == Keys.Left) left = true;
                    if (e.KeyCode == Keys.Space && !isLaunched)
                    {
                        bullet b = new bullet(true, Hero.Left, Hero.Width, Hero.Top, Hero.Height, Hero.attackSpeed, Color.Red,Hero.shotWidth);
                        bullets.Add(b);
                        this.Controls.Add(b);
                        b.BringToFront();
                        isLaunched = true;
                    }


                    if (e.KeyCode == Keys.Tab)
                    {
                        if (Hero.heroChosen == 1) { Hero.BackgroundImage = Properties.Resources.hero2; Hero.speed = 7; Hero.attackSpeed = 5; Hero.shotWidth = 2; }
                        if (Hero.heroChosen == 2) { Hero.BackgroundImage = Properties.Resources.hero3; Hero.speed = 3; Hero.attackSpeed = 2; Hero.shotWidth = 13; }
                        if (Hero.heroChosen == 3) { Hero.BackgroundImage = Properties.Resources.hero1; Hero.speed = 5; Hero.attackSpeed = 4; Hero.shotWidth = 4; }

                        if (Hero.heroChosen != 3) Hero.heroChosen += 1;
                        else Hero.heroChosen = 1;
                    }

                    if (isReady)
                    {

                        if (e.KeyCode == Keys.Z)
                        {
                            difficulty++;
                            labelToStart.Visible = false;
                            lvlabel.Text = "LVL" + difficulty;
                            isReady = false;
                            switch (difficulty)
                            {
                                case 10:
                                    boss1 = new boss1(this.Width/2, -80, 2, 100, 0);
                                    isBoss1 = true;
                                    this.Controls.Add(boss1);
                                    timer2.Enabled = true;
                                    boss1.BringToFront();
                                    break;
                                case 20:
                                    boss2 = new boss2(this.Width / 2, -80, 2, 200, 0);
                                    isBoss2 = true;
                                    this.Controls.Add(boss2);
                                    timer3.Enabled = true;
                                    boss2.BringToFront();
                                    break;

                                default:
                                for (int i = 0; i < 2; i++)
                                {
                                    for (int j = 0; j < 8; j++)
                                    {
                                        int chance;
                                        if (difficulty < 10)
                                        {
                                            chance = rand.Next(100 - difficulty * 10);
                                        }
                                        else chance = 0;
                                        enemy en = new enemy(this.Width - 60 * j - 80 - i * 10, i * 60, 2 + difficulty / 6, (chance == 0) ? 2 : 1, difficulty>20?4:(!(chance == 0)?1:2));
                                        enemies.Add(en);
                                        this.Controls.Add(en);
                                        en.BringToFront();
                                    }
                                }
                                break;
                        }
                        }
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    if (isPaused)
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        timer3.Enabled = true;
                        pause.Enabled = false;
                        pause.Visible = false;
                    }
                    else
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                        pause.Enabled = true;
                        pause.Visible = true;
                        pause.BackColor = Color.Transparent;
                        pause.Dock = DockStyle.Fill;
                    }
                    isPaused = !isPaused;
                }
            }
        }

        private void Bon_onChange(object sender, EventArgs e)
        {
            foreach (bonus bon in bons.ToArray())
            {
                if (bon.Bounds.IntersectsWith(Hero.Bounds))
                {
                   

                    Hero.CheckBonus(bon.Effect);

                    this.Controls.Remove(bon);
                    bons.Remove(bon);                  
                }
            }

        }

        private void Hero_onFireMissiles()
        {
            for (int i = 0; i < 8; i++)
            {
                bullet b = new bullet(true, Hero.Left + i * 20 - 70, Hero.Width, Hero.Top, Hero.Height, Hero.attackSpeed, Color.Red, Hero.shotWidth);
                bullets.Add(b);
                this.Controls.Add(b);
                b.BringToFront();
            }
        }

        private void Hero_onLoseHP()
        {
            HPs--;
            System.Threading.Thread.Sleep(50);
            switch (HPs)
            {
                case 2:
                    hp2.Visible = false;
                    break;
                case 1:
                    hp1.Visible = false;
                    break;
                case 0:
                    hp0.Visible = false;
                    break;
            }
            System.Threading.Thread.Sleep(50);
        }

        private void Hero_onUpgrade()
        {
            iter = 0;
            Hero.BackgroundImage = Properties.Resources.Mandelbrot;
            Hero.speed = 6;
            Hero.attackSpeed = 5;
            Hero.shotWidth = 9;
            timer4.Enabled = true;
        }

        private void Hero_onGetHP()
        {
            if (HPs < 3)
            {
                System.Threading.Thread.Sleep(50);
                switch (HPs)
                {

                    case 2:
                        hp2.Visible = true;
                        break;
                    case 1:
                        hp1.Visible = true;
                        break;
                }
                HPs++;
                System.Threading.Thread.Sleep(50);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            Field.BackgroundImage = Properties.Resources.bg;
            spawnHero();
            timer1.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(isBoss1)
            for (int j = 0; j < 4; j++)
            {
                enemy en = new enemy((boss1.Left+300<this.Width)?(boss1.Left + j*60):boss1.Left - j*60 , boss1.Top+boss1.Height-55, 3, 2, 3);
                enemies.Add(en);
                this.Controls.Add(en);
                en.BringToFront();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(isBoss2)
            for (int j = 0; j < 4; j++)
            {
                enemy en = new enemy((boss2.Left + 300 < this.Width) ? (boss2.Left + j * 60) : boss2.Left - j * 60, boss2.Top + boss2.Height - 55, 3, 2, 4);
                enemies.Add(en);
                this.Controls.Add(en);
                en.BringToFront();
            }
        }
        int iter = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if(iter++==10)
            {
                iter = 0;
                Hero.Reset();
                timer4.Enabled = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) right = false;
            if (e.KeyCode == Keys.Left) left = false;
            if (e.KeyCode == Keys.Space) isLaunched = false;
            if (e.KeyCode == Keys.S) isSdown = false;
            if (e.KeyCode == Keys.ControlKey) isCtrldown = false;
            if (e.KeyCode == Keys.Y) isYdown = false;
        }
       
    }
}
