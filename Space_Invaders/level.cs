using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    [Serializable]
    class level
    {
        public int score;
        public int difficulty;
        public int HPs;
        public level(int score, int difficulty, int HPs)
        {
            this.score = score;
            this.difficulty=difficulty;
            this.HPs = HPs;
        }
    }
}
