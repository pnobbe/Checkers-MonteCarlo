using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {

        const int numOfSimulations = 1000;
        const int numOfMCiterations = 100;


        static void Main(string[] args)
        {

            int draws = 0;
            int p1w = 0;
            int p2w = 0;

            Dictionary<Int32, Int32> map = new Dictionary<Int32, Int32>();
            for (int i = 0; i < numOfSimulations; i++)
            {
                int x = Randomizer.getRnd(9);

                if (!map.Keys.Contains(x))
                    map[x] = 0;

                map[x]++;
            }

            Console.WriteLine("Monte Carlo ends after " + numOfMCiterations + " iterations.");
            Console.WriteLine("Simulating " + numOfSimulations + " games. \n");
            Console.WriteLine("Starting simulations...");
            Console.WriteLine();

            for (int i = 0; i < numOfSimulations; i++)
            {
                
                switch (sim((i % 2) + 1))
                {
                    case 0: Console.Write("-"); draws++; break;
                    case 1: Console.Write("1"); p1w++; break;
                    case 2: Console.Write("2"); p2w++; break;
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // AI vs AI always results in a draw! We made a Minimax equivalent!

            Console.WriteLine("Draws: " + draws);
            Console.WriteLine("P1 Win: " + p1w);
            Console.WriteLine("P2 Win: " + p2w);

            // Stop application
            Console.ReadLine();

        }

        public static int sim(int player)
        {
            MonteCarloTreeSearch mcts = new MonteCarloTreeSearch(numOfMCiterations);
            Board board = new Board();

            int totalMoves = Board.DEFAULT_BOARD_SIZE * Board.DEFAULT_BOARD_SIZE;

            for (int i = 0; i < totalMoves; i++)
            {
                board = mcts.findNextMove(board, player);
                if (board.checkStatus() != -1)
                {
                    break;
                }
                player = 3 - player;
            }

            return board.checkStatus();

        }
    }
}
