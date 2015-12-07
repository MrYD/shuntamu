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
    class Boss : MotionObject, IKiller, IEnemy
    {
        private const int maxlife = 10;
        private int life = maxlife;
        private Point clearPoint;
        private Point basePoint;
        private Size baseSize = new Size(150, 150);
        public Boss(Point top) : base(top, new Size())
        {
            basePoint = top;
            this.Size = baseSize;
            clearPoint = top + new Size(100, 100);
        }

        private Point barmaxtop = new Point(750, 380);
        private Size barmaxsize = new Size(25, 200);

        private Point bartop
        {
            get
            {
                return new Point(barmaxtop.X, barBottom.Y - (int)(barmaxsize.Height * life / maxlife));
            }
        }
        private Point barBottom
        {
            get { return barmaxtop + barmaxsize; }
        }
        private void drawbar()
        {
            if (life > 5)
            {
                DX.DrawBox(bartop.X, bartop.Y, barBottom.X, barBottom.Y, DX.GetColor(0, 255, 0),
               DX.TRUE);
            }
            else if (life > 2)
            {
                DX.DrawBox(bartop.X, bartop.Y, barBottom.X, barBottom.Y, DX.GetColor(180, 180, 0),
              DX.TRUE);
            }
            else
            {
                DX.DrawBox(bartop.X, bartop.Y, barBottom.X, barBottom.Y, DX.GetColor(180, 0, 0),
              DX.TRUE);
            }
            DX.DrawBox(barmaxtop.X, barmaxtop.Y, barBottom.X, barBottom.Y, DX.GetColor(250, 250, 250),
              DX.FALSE);
            DX.DrawString(barmaxtop.X - 5, barmaxtop.Y - 15, "BOSS", DX.GetColor(255, 255, 255));
        }
        public override void Draw(Point top, Size size)
        {
            DX.DrawBox(top.X, top.Y, top.X + size.Width, top.Y + size.Height, DX.GetColor(0, 255, 0), DX.TRUE);
            drawbar();
        }

        public override void Update(MapBase map)
        {
            if (GameTimer.Loop(100) == 0 || Input.Instance.Z)
            {
                var rand = new Random();
                var bullet = new BossBullet(new Point(Point.X + rand.Next(-100, 100), Point.Y + rand.Next(-100, 100)));
                map.AddElement(bullet);
                map.UpdateElement();
            }

            Size = new Size(Math.Abs((int)(baseSize.Width * Math.Sin(GameTimer.Frame / 50.0))), Math.Abs((int)(baseSize.Height * Math.Sin(GameTimer.Frame / 50.0))));
            Top = basePoint + new Size((baseSize.Width - Size.Width)/2, (baseSize.Height - Size.Height)/2);
            base.Update(map);
        }

        internal override void Death()
        {
            IsActive = false;
            new ClearObject(clearPoint).AddTo(Map);
            Map.UpdateElement();
            base.Death();
        }

        public void Kill(MapElementBase target)
        {
            target.Death();
        }

        public void Damage()
        {
            life--;
            if (life < 0)
            {
                Death();
            }
        }
    }
}
