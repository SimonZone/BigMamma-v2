using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMamma_v2
{
    public class NumberGenerator
    {
        private Random _generator;

        public NumberGenerator()
        {
            _generator = new Random();
        }

        public int Next(int min, int max)
        {
            int value = min + _generator.Next(max - min + 1);
            return value;
        }
    }
}
