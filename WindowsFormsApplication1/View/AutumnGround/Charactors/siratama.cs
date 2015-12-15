using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.AutumnGround.Charactors
{
    class Siratama : MotionObject, IEnemy,IKiller
    {
        public Siratama(Point top)
            : base(top, new Size(32,32))
        {

        }

        public override void Update(MapBase map)
        {
            //int y = 5;
            //int x = 0;
            //Distance = new Point(x, y);

            //base.Update(map);
        }

        private int siraHandle01 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama01.png");
        private int siraHandle02 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama02.png");
        private int siraHandle03 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama03.png");
        private int siraHandle04 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama04.png");
        private int siraHandle05 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama05.png");
        private int siraHandle06 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama06.png");
        private int siraHandle07 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama07.png");
        private int siraHandle08 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama08.png");
        private int siraHandle09 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama09.png");
        private int siraHandle10 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama10.png");
        private int siraHandle11 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprSiratama11.png");

        public override void Draw(Point top, Size size)
        {
            double flame = GameTimer.Loop(20);
            if (flame <= 1 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle01, DX.TRUE);
                return;
            }
            if (flame > 1 / 20.0 && flame <= 2 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle02, DX.TRUE);
                return;
            }
            if (flame > 2 / 20.0 && flame <= 3 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle03, DX.TRUE);
                return;
            }
            if (flame > 3 / 20.0 && flame <= 4 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle04, DX.TRUE);
                return;
            }
            if (flame > 4 / 20.0 && flame <= 5 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle05, DX.TRUE);
                return;
            }
            if (flame > 5 / 20.0 && flame <= 6 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle06, DX.TRUE);
                return;
            }
            if (flame > 6 / 20.0 && flame <= 7 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle07, DX.TRUE);
                return;
            }
            if (flame > 7 / 20.0 && flame <= 8 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle08, DX.TRUE);
                return;
            }
            if (flame > 8 / 20.0 && flame <= 9 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle09, DX.TRUE);
                return;
            }
            if (flame > 9 / 20.0 && flame <= 10 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle10, DX.TRUE);
                return;
            }
            if (flame > 10 / 20.0)
            {
                DX.DrawGraph(top.X, top.Y, siraHandle11, DX.TRUE);
                return;
            }
            //int r = size.Height / 2;
            //DX.DrawCircle(top.X + r, top.Y + r, r, DX.GetColor(200, 200, 200));
        }

        public void Damage()
        {
            IsActive = false;
            SoundManager.Play("death",DX.DX_PLAYTYPE_BACK);
        }

        public void Kill(MapElementBase target)
        {
            target.Death();
        }
    }
}
