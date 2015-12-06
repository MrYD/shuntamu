using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.Util
{
    class GameTimer
    {
        public static long Frame { get; set; }

        public static double Loop(int span)
        {
            return (((int)Frame) % span) / (double)span;
        }
        public static void Update()
        {
            Frame++;
        }
    }
}
