using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View
{
    abstract class DrawHub: List<IDrawable>,IDrawable
    {
        public void Draw()
        {
            foreach (var Itr in this)
            {
                Itr.Draw();
            }
            ;
        }

    }
}
