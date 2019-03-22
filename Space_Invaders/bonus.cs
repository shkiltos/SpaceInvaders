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
    class bonus : PictureBox
    {
        public int speed;
        private int h;
        private int effect;
        public event EventHandler onChange;
        public int H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
                onChange(this, new EventArgs());
            }
        }

        public int Effect
        {
            get { return effect; }        
        }
   

        public bonus(int x, int y, int speed,int effect)
        {          
            this.Size = new Size(30, 30);
            this.Top = y;
            this.Left = x;

            switch (effect)
            {
                case 0: this.BackgroundImage = Properties.Resources.bonusHP; break;
                case 1: this.BackgroundImage = Properties.Resources.bonusUpgrade; break;
                case 2: this.BackgroundImage = Properties.Resources.bonusBomb; break;
                case 3: this.BackgroundImage = Properties.Resources.bonusMissile; break;
            }

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.speed = speed;
            this.effect = effect;
        }
    }
}
