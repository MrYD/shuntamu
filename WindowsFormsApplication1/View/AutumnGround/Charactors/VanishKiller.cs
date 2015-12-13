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
    class VanishKiller:MotionObject,IEnemy,IKiller
    {
        public MotionlessObject Trigger { get; set; }

        private bool _isTriggered = false;
        private int skinHandle;

        public VanishKiller(Point top,Point triggerTop,Size triggerSize,Skin skin) 
            : base(top, new Size(32,32))
        {
            skinHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringi_S.png");
            Trigger = new MotionlessObject(triggerTop, triggerSize);
            Trigger.IsSolid = false;
            Trigger.BeHitEvent += () =>
            {
                _isTriggered = true;
            };

            switch (skin)
            {
                case Skin.EringiUp:
                    skinHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringi_S.png");
                    Size = new Size(32, 32);
                    break;
                case Skin.EringiDown:
                    skinHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringiDownS.png");
                    Size = new Size(32, 32);
                    break;
                case Skin.LongEringiUp:
                    skinHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/longEringiUp.png");
                    Size = new Size(32, 64);
                    break;
                case Skin.LongEringiDown:
                    skinHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/longEringiDown.png");
                     Size = new Size(32, 64);
                    break;
            }
        }

        public new MapElementBase AddTo(MapBase map)
        {
            Map = map;
            map.AddElement(this);
            map.AddElement(Trigger);
            return this;
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, skinHandle, DX.TRUE);
        }

        public override void Update(MapBase map)
        {
            if (_isTriggered)
            {
                if (_isTriggered)
                {
                    SoundManager.Play("death", DX.DX_PLAYTYPE_BACK);
                }
                IsActive = false;
            }
        }

        public void Damage()
        {
        }

        public void Kill(MapElementBase target)
        {
            target.Death();
        }
    }
}
