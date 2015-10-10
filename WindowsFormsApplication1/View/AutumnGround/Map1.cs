using System.Drawing;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(new Size(1000, 1000))
        {

            var floor = new MotionlessObject(new Point(0, 500), new Size(1000, 100));
            var floor2 = new MotionlessObject(new Point(500, 140), new Size(100, 2000));
            var siratama = new Siratama(new Point(250,150),new Size(40,40) );
            AddElement(floor);
            AddElement(floor2);
            AddElement(siratama);
        }
    }
}
