using System.Drawing;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(new Size(1000, 1000))
        {

            var floor = new MotionlessObject(new Point(0, 500), new Size(1000, 100));
            var floor2 = new MotionlessObject(new Point(500, 140), new Size(100, 2000));
            AddElement(floor);
            AddElement(floor2);
        }
    }
}
