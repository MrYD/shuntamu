using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround.Charactors
{
    class VanishBlock:Rock1,IKiller
    {

        public VanishBlock(Point top, Size size) : base(top, size)
        {
        }


        public void Kill(MapElementBase target)
        {
            IsActive = false;
            Map.UpdateElement();
        }
    }
}
