using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame
{
    class Craps
    {
        private enum DiceSums { SNAKE_EYES = 2, TREY = 3, SEVEN = 7, YO_LEVEN = 11, BOX_CARS = 12 }
        private enum GameStatus { WIN, LOSE, PLAY_MORE }
        private Roll rolls;
        private GameStatus gameStatus;
        public const int NUM_GAMES = 1000;
        private int numRolls;
        private Statistics stats;

        public Craps()
        {
            rolls = new Roll();
            gameStatus = GameStatus.PLAY_MORE;
            numRolls = 1;
            stats = new Statistics();
        }

        public int Sum { get; set; }
        public int Point { get; set; }

        public void PlayGame()
        {
            for (int i = 0; i < NUM_GAMES; i++)
            {
                Console.WriteLine("********** Game # " + (i + 1) + " **********");
                numRolls = 1;
                gameStatus = GameStatus.PLAY_MORE;
                while (gameStatus == GameStatus.PLAY_MORE)
                {
                    Sum = rolls.RollDice();
                    EvaluateRoll();
                    DisplayMessages();
                    while (gameStatus == GameStatus.PLAY_MORE)
                    {
                        KeepPlaying();
                        numRolls++;
                        DisplayMessages();
                    }
                }
            }
            stats.DisplayStats();
        }

        private void KeepPlaying()
        {
            Sum = rolls.RollDice();
            if (Sum == Point)
            {
                gameStatus = GameStatus.WIN;
                stats.SetStats(numRolls, "WIN");
            }
            else if (Sum == 7)
            {
                gameStatus = GameStatus.LOSE;
                stats.SetStats(numRolls, "LOSE");
            }
            else
                gameStatus = GameStatus.PLAY_MORE;
        }

        private void DisplayMessages()
        {
            switch (gameStatus)
            {
                case GameStatus.WIN:
                    Console.WriteLine("Congragulations, you rolled {0}. YOU WIN.", Sum);
                    break;
                case GameStatus.LOSE:
                    Console.WriteLine("Sorry, you rolled {0}. YOU LOSE.", Sum);
                    break;
                default:
                    if (numRolls == 1)
                        Console.WriteLine("Your Point is {0}. Keep rolling!", Point);
                    else
                        Console.WriteLine("Your Point is {0}. You rolled {1}. Keep rolling!", Point, Sum);
                    break;
            }
        }

        private void EvaluateRoll()
        {
            switch ((DiceSums)Sum)
            {
                case DiceSums.SEVEN:
                case DiceSums.YO_LEVEN:
                    gameStatus = GameStatus.WIN;
                    Point = 0;
                    stats.SetStats(numRolls, "WIN");
                    break;
                case DiceSums.SNAKE_EYES:
                case DiceSums.TREY:
                case DiceSums.BOX_CARS:
                    gameStatus = GameStatus.LOSE;
                    Point = 0;
                    stats.SetStats(numRolls, "LOSE");
                    break;
                default:
                    gameStatus = GameStatus.PLAY_MORE;
                    Point = Sum;
                    break;
            }
        }
    }
}
