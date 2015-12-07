using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.Util
{
    internal class Animation
    {
        public Animation(int span, Action<double> animation)
        {
            _span = span;
            _animation = animation;
        }

        private long _flame;
        private int _span;
        private Action<double> _animation;

        public void Draw()
        {
            _flame++;
            _animation(((int)_flame % _span) / (double)_span);
        }

    }
}
