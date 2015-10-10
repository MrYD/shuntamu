using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class Siratama:MotionObject
    {
        public Siratama(Point top, Size size) : base(top, size)
        {
           
        }
    

        public override void Update(MapBase map)
        {
            int y=5;
            int x=0;
            Distance=new Point(x,y);
            base.Update(map);
        }
    }
}
