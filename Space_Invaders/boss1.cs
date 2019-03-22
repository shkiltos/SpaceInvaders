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
    class boss1 : enemy
    {
        public bool bossDir = true;
        public override void dance(Random rand, bool direction, int difficulty, int Left, List<bullet> bullets, Form Form1)
        {
            if (direction) this.Left += this.speed;
            else this.Left -= this.speed;

            if (rand.Next(120) == 0)
            {
                bullet b1 = new bullet(false, this.Left - 50, this.Width, this.Top + this.Height - 30, this.Height, 2 + difficulty / 7, Color.MediumPurple,4);
                bullets.Add(b1);
                Form1.Controls.Add(b1);
                b1.BringToFront();
                bullet b2 = new bullet(false, this.Left + 20, this.Width, this.Top + this.Height - 50, this.Height, 2 + difficulty / 7, Color.MediumPurple,4);
                bullets.Add(b2);
                Form1.Controls.Add(b2);
                b2.BringToFront();
                bullet b3 = new bullet(false, this.Left -20, this.Width, this.Top + this.Height - 70, this.Height, 2 + difficulty / 7, Color.MediumPurple,4);
                bullets.Add(b3);
                Form1.Controls.Add(b3);
                b3.BringToFront();
            }
        }

        public boss1( int x, int y, int speed, int hp, int isUsual):base(x,y,speed,hp,isUsual)
        {
            this.Image = Properties.Resources.octo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.Transparent;
            //this.BackColor = Color.Red;
            this.Size = new Size(200, 200);
            this.Tag = "boss1";
            this.Left = x;
            this.Top = 150 + y;
            this.speed = speed;
            this.healthPoints = hp;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }
    }
}
