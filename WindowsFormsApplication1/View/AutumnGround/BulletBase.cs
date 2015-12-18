using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround
{
    class BulletBase: MotionObject
    {
        private int bulletHandle;
        public BulletBase(Point top, Size size,string path) : base(top, size)
        {
            IsSolid = false;
            HitEvent += obj =>
            {
                IsActive = false;              
            };
            bulletHandle = DX.LoadGraph(path);
        }
        public override void Update(MapBase map)
        {
            _bulletLife++;
            if (_bulletLife > 50)
            {
                IsActive = false;
            }
            base.Update(map);
        }
        private int _bulletLife;
        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, bulletHandle, DX.TRUE);
        }
    }
}
