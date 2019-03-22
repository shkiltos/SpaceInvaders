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
    class hero : PictureBox
    {
        public int health;
        public int speed;
        public int attackSpeed;
        public int shotWidth;
        public int heroChosen=1;

        public delegate void MethodContainer1();
        public delegate void MethodContainer2();
        public delegate void MethodContainer3();
        public delegate void MethodContainer4();

        public event MethodContainer1 onGetHP;
        public event MethodContainer2 onUpgrade;
        public event MethodContainer3 onLoseHP;
        public event MethodContainer4 onFireMissiles;

        public hero(int widowWidth, int widowHeight)
        {
            this.BackgroundImage = Properties.Resources.hero1;
            //this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size = new Size(75, 90);
            this.Left = widowWidth / 2 - 40;
            this.Top = widowHeight - 130;
            this.health = 3;
            this.speed = 5;
            this.attackSpeed = 4;
            this.shotWidth=4;
        }

        public void Reset()
        {
            this.BackgroundImage = Properties.Resources.hero1;
            this.speed = 5;
            this.attackSpeed = 4;
            this.shotWidth = 4;
            this.heroChosen = 1;
        }

        public void CheckBonus(int eff)
        {
            switch (eff)
            {
                case 0: onGetHP(); break;
                case 1: onUpgrade(); break;
                case 2: onLoseHP(); break;
                case 3: onFireMissiles(); break;
            }
        }
    }
}
