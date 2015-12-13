using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class MotionKiller :MotionObject, IEnemy,IKiller
    {

        public MotionlessObject Erea { get; set; }

        private int eringiHandle;
        private bool _isTrigered = false;
        int y;
        int x;

        public void Damage()
        {
        }

        public MotionKiller(Point top, Point ereatop, Size ereasize,int moveX,int moveY,Skin skin)
            : base(top, new Size(32, 32))
        {
            Erea = new MotionlessObject(ereatop, ereasize);
            Erea.IsSolid = false;
            Erea.BeHitEvent += () =>
            {
                _isTrigered = true;
            };
            x = moveX;
            y = moveY;

            switch (skin)
            {
                case Skin.EringiUp:
                    eringiHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringi_S.png");
                    Size = new Size(32, 32);
                    break;
                case Skin.EringiDown:
                    eringiHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringiDownS.png");
                    Size = new Size(32, 32);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("skin", skin, null);
            }
        }

        public new MapElementBase AddTo(MapBase map)
        {
            Map = map;
            map.AddElement(this);
            map.AddElement(Erea);
            return this;
        } 

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, eringiHandle, DX.TRUE);
        }

        public override void Update(MapBase map)
        {
            if (_isTrigered)
            {
                Distance = new Point(x, y);         
            }
            else
            {
                Distance = new Point(0, 0);     
            }
            base.Update(map);
           
        }

        public void Kill(MapElementBase target)
        {
            target.Death();
        }
    }
}
