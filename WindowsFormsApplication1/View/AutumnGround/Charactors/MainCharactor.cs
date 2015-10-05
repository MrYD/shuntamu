using System.Collections.Generic;
using System.Drawing;

namespace shuntamu.View
{
    class MainCharactor : MotionObject
    {
        public MainCharactor()
            : base(new Size(100, 0), new Size(50, 100))
        {
            Distance=new Size(2,2);
        }
    }
}
