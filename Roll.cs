using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame
{
    class Roll
    {
        private Random rand;

        public Roll()
        {
            rand = new Random();
        }

        public int Die1 { get; set; }
        public int Die2 { get; set; }

        public int RollDice()
        {
            Die1 = rand.Next(1, 7);
            Die2 = rand.Next(1, 7);

            return Die1 + Die2;
        }
    }
}
