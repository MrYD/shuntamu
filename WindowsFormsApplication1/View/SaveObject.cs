using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View
{
    class SaveObject : MotionlessObject,IEnemy
    {
        private static Point _restartPoint = new Point(32, 128);

        public SaveObject(Point top)
            : base(top, new Size(32, 32))
        {

        }

        public static Point RestartPoint
        {
            get { return _restartPoint; }
            set { _restartPoint = value; }
        }

        private int handle = DX.LoadGraph(@"IWBT素材\スプライト\ゴールオーブ.png");
        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, handle, DX.TRUE);
        }

        public void Save()
        {
            RestartPoint = new Point(Top.X, Top.Y - 96);
        }

        public void Damage()
        {
            Save();
        }
    }
}
