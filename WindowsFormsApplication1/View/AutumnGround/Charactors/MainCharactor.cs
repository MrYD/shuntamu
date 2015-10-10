using System;
using System.Drawing;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.AutumnGround.Charactors
{
    class MainCharactor : MotionObject
    {
        public MainCharactor()
            : base(new Point(100, 0), new Size(50, 100))
        {
            HitYEvent += obj =>
            {
                _vy = 0;
                if (Input.Instance.LeftShift)
                {
                    _vy = -30;
                }      
            };
            HitXEvent += obj =>
            {
                _vx = 0;
            };
            HitEvent += obj =>
            {
                if (obj is MotionObject)
                {
                    DX.DrawString(400, 200, "Game Over", DX.GetColor(200, 200, 200));
                }
            };

        }

        private float _vx = 0;
        private float _vy = 0;

        private int Vx
        {
            get
            {
                if (_vx > 5)
                {
                    _vx = 5;
                }
                else if (_vx < -5)
                {
                    _vx = -5;
                }
                else
                {
                    _vx += +ax / m;
                }
                return (int)_vx;
            }
        }

        private int Vy
        {
            get
            {
                if (_vy > 5)
                {
                    _vy = 5;
                }
                else if (_vy < -20)
                {
                    _vy = -20;
                }
                else
                {
                    _vy += +ay / m;
                }
                return (int)_vy;
            }
        }
        private float ax;
        private float ay;
        private float m = 10f;

        public override void Update(MapBase map)
        {
            ay = 5;
            if (Input.Instance.Right)
            {
                ax = 5;
            }
            else if (Input.Instance.Left)
            {
                ax = -5;
            }
            else
            {
                ax = 0;
                _vx = 0;
            }           
            base.Update(map);
            Distance = new Point(Vx, Vy);
        }

        public override void Draw(Point top, Size size)
        {
           // DX.DrawCircle(top.X, top.Y, 10, DX.GetColor(200, 200, 200));
            base.Draw(top,size);
        }
    }
}
