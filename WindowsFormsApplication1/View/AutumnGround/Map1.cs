using System.Drawing;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(new Size(1000, 1000))
        {
            var floor = new MotionlessObject(new Point(0, 500), new Size(1000, 100));
            AddElement(floor);
        }
    }
}
