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
        
        private const int maxlife = 11;
        private int life = maxlife;
        private Point clearPoint;
        private Point clearBlockPoint;
        private Size clearBlockSize;
        private Point basePoint;
        private Size baseSize = new Size(96,96);
        public Boss(Point top) : base(top, new Size())
        {
            basePoint = top;
            this.Size = baseSize;
            clearPoint = top + new Size(100, 100);
            clearBlockPoint = new Point(6240,256);
            clearBlockSize = new Size(256,352);
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
        

        public override void Update(MapBase map)
        {
            if (GameTimer.Loop(100) == 0 || Input.Instance.Z)
            {
                var rand = new Random();
                //var bullet = new BossBullet(new Point(Point.X + rand.Next(-100, 100), Point.Y + rand.Next(-100, 100)));
                var bullet = new BossBullet(new Point(Top.X-16, Top.Y + Size.Height/2));
                
                //map.AddElement(bullet);
                map.UpdateElement();
            }

            //Size = new Size(Math.Abs((int)(baseSize.Width * Math.Sin(GameTimer.Frame / 50.0))), Math.Abs((int)(baseSize.Height * Math.Sin(GameTimer.Frame / 50.0))));
            //Top = basePoint + new Size((baseSize.Width - Size.Width)/2, (baseSize.Height - Size.Height)/2);
            base.Update(map);
        }

        internal override void Death()
        {
            IsActive = false;
            new ClearObject(clearPoint).AddTo(Map);
            new Rock1(clearBlockPoint, clearBlockSize).AddTo(Map);
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
            SoundManager.Play("damage",DX.DX_PLAYTYPE_BACK);
            if (life < 1)
            {
                SoundManager.Play("death",DX.DX_PLAYTYPE_BACK);
                SoundManager.Stop("BGM");
                Death();
            }
        }

        private int bossHandle1 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprBigSiratama01.png");
        private int bossHandle2 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprBigSiratama12.png");
        public override void Draw(Point top, Size size)
        {
            if (life == maxlife)
            {
                DX.DrawGraph(top.X-16, top.Y-16, bossHandle2, DX.TRUE);
            }
            else
            {
                drawbar();
                int rotaSpeed = life*5;
                double radian = GameTimer.Loop(rotaSpeed)*-2*3.14;
                DX.DrawRotaGraph(top.X + size.Width/2, top.Y + size.Height/2, 1.0, radian, bossHandle1, DX.TRUE);
            }
        }
    }
}
