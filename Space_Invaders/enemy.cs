using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    [Serializable]
    class enemy : PictureBox
    {
        public int speed;
        public int healthPoints;

        public virtual void dance(Random rand,bool direction,int difficulty,int Left, List<bullet> bullets, Form Form1)
        {
            if (direction) this.Left += this.speed;
            else this.Left -= this.speed;

            if (rand.Next(500 - difficulty * 10) == 0)
            {
                bullet b = new bullet(false, this.Left, this.Width, this.Top + this.Height, this.Height, 2 + difficulty / 7, Color.MediumPurple,4);
                bullets.Add(b);
                Form1.Controls.Add(b);
                b.BringToFront();
            }
        }

        public enemy(int x, int y,int speed,int hp,int isUsual)
        {
            switch (isUsual)
            {
                case 1:
                    this.Image = Properties.Resources.invader;
                break;
                case 2:
                    this.BackgroundImage = Properties.Resources.ufo;
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources.octomonster;
                    break;
                case 4:
                    this.BackgroundImage = Properties.Resources.invader2;
                    break;
            }
            this.BackgroundImageLayout = ImageLayout.Zoom;
            
            this.Size = new Size(40, 40);
            this.Tag = "enemy";
            this.Left = x;
            this.Top = 40+y;
            this.speed = speed;
            this.healthPoints = hp;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }
    }
}
