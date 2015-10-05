using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround
{
    class Map1:Map
    {
         public Map1()
        {
            Square floor = new Square(new Size(0, 500), new Size(900, 100));
            Add(floor);
        }
    }
}
