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
    class bullet : PictureBox
    {
        private int speed;
        private bool ownBullet;

        public bool OwnBullet
        {
            get { return ownBullet; }
        }
        
        public int Speed
        {
            get { return speed; }
        }

        public bullet(bool ownBullet,int left, int width, int top, int height, int speed,Color color,int bulWidth)
        {
            this.BackColor = color;
            this.Size = new Size(bulWidth, 10);
            this.Tag = "bullet";
            this.Left = left + width / 2 - this.Width / 2;
            this.Top = top ;
            this.speed = speed;
            this.ownBullet = ownBullet;
        }
    }
}
