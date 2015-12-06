using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround.Charactors
{
    class BossBullet : BulletBase,IKiller
    {
        public BossBullet(Point top) : base(top, new Size(20, 20), "")
        {
            double x = MainCharactor.Instance.Top.X -5 - top.X;
            double y = MainCharactor.Instance.Top.Y -5 - top.Y;
            Distance = new Point(-10, (int)(-10 * y / x));
        }

        public override void Draw(Point top, Size size)
        {
            DxLibDLL.DX.DrawCircle(top.X - 10, top.Y - 10, 10, DxLibDLL.DX.GetColor(255, 0, 0));
            base.Draw(top, size);
        }

        public void Kill(MapElementBase target)
        {
           target.Death();
        }
    }
}
