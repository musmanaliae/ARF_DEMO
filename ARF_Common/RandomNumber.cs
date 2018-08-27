using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARF_Common
{
    public class RandomNumber
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int GenerateRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
