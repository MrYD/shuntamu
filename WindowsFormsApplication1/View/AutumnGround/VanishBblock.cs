using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround.Charactors
{
    class VanishBblock:Rock1,IKiller
    {

        public VanishBblock(Point top, Size size) : base(top, size)
        {
        }


        public void Kill(MapElementBase target)
        {
            IsActive = false;
            Map.UpdateElement();
        }
    }
}
