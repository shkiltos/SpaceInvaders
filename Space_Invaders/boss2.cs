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
    class boss2 : enemy
    {
        public bool bossDir = true;
        public override void dance(Random rand, bool direction, int difficulty, int Left, List<bullet> bullets, Form Form1)
        {
            if (direction) this.Left += this.speed;
            else this.Left -= this.speed;

            if (rand.Next(80) == 0)
            {
                bullet b1 = new bullet(false, this.Left-75, this.Width, this.Top + this.Height-75, this.Height, 6, Color.MediumPurple,4);
                bullets.Add(b1);
                Form1.Controls.Add(b1);
                b1.BringToFront();
                bullet b2 = new bullet(false, this.Left+75, this.Width, this.Top + this.Height-75, this.Height, 6, Color.MediumPurple,4);
                bullets.Add(b2);
                Form1.Controls.Add(b2);
                b2.BringToFront();
            }
        }
        public boss2(int x, int y, int speed, int hp, int isUsual) : base(x, y, speed, hp, isUsual)
        {
            this.Image = Properties.Resources.demon;
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