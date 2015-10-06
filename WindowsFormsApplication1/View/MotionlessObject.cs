using System.Drawing;

namespace shuntamu.View
{
    /// <summary>
    /// 静止する Map要素
    /// </summary>
    class MotionlessObject : MapElementBase
    {
        public MotionlessObject(Point top, Size size)
            : base(top, size)
        {
        }
    }
}
