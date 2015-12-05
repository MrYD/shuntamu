using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class DropEryngii :MotionObject, IEnemy,IKiller
    {

        public MotionlessObject Erea { get; set; }

        private bool _isTrigered = false;

        public void Damage()
        {
        }

        public DropEryngii(Point top, Point ereatop, Size ereasize)
            : base(top, new Size(32, 32))
        {
            eringiHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringi_S.png");
            Erea = new MotionlessObject(ereatop, ereasize);
            Erea.IsSolid = false;
            Erea.BeHitEvent += () =>
            {
                _isTrigered = true;
            };
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
                int y = 5;
                int x = 0;
                Distance = new Point(x, y);         
            }
            else
            {
                Distance = new Point(0, 0);     
            }
            base.Update(map);
           
        }

        private int eringiHandle;
        public void Kill(MapElementBase target)
        {
            target.Death();
        }
    }
}
