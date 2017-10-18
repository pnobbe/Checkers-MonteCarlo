using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    public static class Randomizer
    {
        private static Random rnd;

        public static int getRnd(int x)
        {
            if (rnd == null)
            {
                rnd = new Random();
            }

            return (int) (rnd.NextDouble() * x);
        }

        public static double getRnd()
        {
            if (rnd == null)
            {
                rnd = new Random();
            }

            return rnd.NextDouble();

        }
    }
}
