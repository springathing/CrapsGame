using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame
{
    class Statistics
    {
        public static int[] wins = new int[22];
        public static int[] losses = new int[22];

        public double AverageLength()
        {
            double average = 0;
            int sumOfRounds = 0;

            for (int i = 1; i <= 21; i++)
            {
                sumOfRounds += (wins[i] * i) + (losses[i] * i);
            }

            average = (sumOfRounds * 1.0) / (wins.Sum() + losses.Sum());

            return average;
        }

        public void DisplayStats()
        {
            double probability = 0;
            double average = 0;

            for (int i = 1; i <= 21; i++)
            {
                if (i == 21)
                    Console.WriteLine("Round 21 or more wins: {0}:", wins[i]);
                else
                    Console.WriteLine("Round {0} wins: {1}: ", i, wins[i]);
            }

            for (int i = 1; i <= 21; i++)
            {
                if (i == 21)
                    Console.WriteLine("Round 21 or more losses: {0}:", losses[i]);
                else
                    Console.WriteLine("Round {0} losses: {1}: ", i, losses[i]);
            }

            probability = ProbabilityOfWinning();
            Console.WriteLine("Chances of winning the game of Craps are {0}", probability.ToString("P"));
            average = AverageLength();
            Console.WriteLine("Average length of the game of Craps is {0}", average.ToString("N3"));
        }

        public double ProbabilityOfWinning()
        {
            return (wins.Sum() * 1.0 / (wins.Sum() + losses.Sum()));
        }

        public void SetStats(int round, string result)
        {
            if (result == "WIN")
            {
                if (round <= 20)
                {
                    wins[round] += 1;
                }
                else
                    wins[21] += 1;
            }
            else if (result == "LOSE")
            {
                if (round <= 20)
                {
                    losses[round] += 1;
                }
                else
                    losses[21] += 1;
            }
        }
    }
}
