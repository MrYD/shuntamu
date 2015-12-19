using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.Util;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View
{
    class SaveObject : MotionlessObject, IEnemy
    {
        private static Point _restartPoint = new Point(64, 128);
        //private static Point _restartPoint = new Point(1408 + 48, 480 - 32);
        //private static Point _restartPoint = new Point(2560 + 48, 224 - 32);
        //private static Point _restartPoint = new Point(3744 + 48, 448 - 32);
        //private static Point _restartPoint = new Point(5376 + 48, 224 - 32);

        public SaveObject(Point top)
            : base(top, new Size(32, 32))
        {
            IsSolid = false;
        }

        public static Point RestartPoint
        {
            get { return _restartPoint; }
            set { _restartPoint = value; }
        }

        private int handle = DX.LoadGraph(@"../../IWBT素材/スプライト/saveFlag.png");
        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, handle, DX.TRUE);
        }

        public void Save()
        {
            RestartPoint = new Point(Top.X + 48, Top.Y - 32);
            SoundManager.Play("save",DX.DX_PLAYTYPE_BACK);
            IsActive = false;
            Map.UpdateElement();
        }

        public void Damage()
        {
            Save();
        }
    }
}
