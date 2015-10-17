using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class Siratama:MotionObject,IEnemy
    {
        public Siratama(Point top, Size size) : base(top, size)
        {
            
        }
    


        public override void Update(MapBase map)
        {
            int y=5;
            int x=0;
            Distance=new Point(x,y);

            base.Update(map);
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawCircle(top.X+20, top.Y+20, 20, DX.GetColor(200, 200, 200));
        }

        public void Damage()
        {
            IsActive = false;
        }
    }
}
