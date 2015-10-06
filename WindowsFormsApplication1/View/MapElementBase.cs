using System.Drawing;

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
