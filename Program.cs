using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Craps craps = new Craps();
            craps.PlayGame();
            Console.ReadLine();
        }
    }
}
