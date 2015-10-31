using System.Drawing;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(100)
        {
            var floor = new Floor(new Point(0, 500), new Size(10000, 100));
            var floor2 = new MotionlessObject(new Point(500, 300), new Size(100, 200));
            var siratama = new Siratama(new Point(250,150),new Size(100,100) );
            var saveobject = new SaveObject(new Point(550,150));
            AddElement(floor);
            AddElement(floor2);
            AddElement(siratama);
            AddElement(saveobject);
            MotionObject obj;
            for (int i = 1; i < 500; i++)
            {
                obj = new Siratama(new Point(250 + 200 * i, 150), new Size(40, 40));
                AddElement(obj);
            }

            UpdateElement();
        }
    }
}
