using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View
{
    /// <summary>
    /// Map に追加可能な要素
    /// </summary>
    abstract class MapElementBase : Square
    {
        protected MapElementBase(Point top, Size size)
            : base(top, size)
        {
        }
    }
}
