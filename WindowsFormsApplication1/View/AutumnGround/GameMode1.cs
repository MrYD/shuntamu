using System.Drawing;
using System.Drawing.Text;
using DxLibDLL;
using shuntamu.Util;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class GameMode1 : ModeBase
    {
        private Map1 _map1;
        private MainCharactor _mario;
        int backgroundHandle = DX.LoadGraph(@"../../IWBT素材/背景/夜_トランジション.png");
       
        public GameMode1()
        {
            Init();
        }

        public override void Init()
        {
            SoundManager.Stop();
            SoundManager.Play("BGM",DX.DX_PLAYTYPE_LOOP);
            _mario = MainCharactor.Instance;
            _mario.Init();
            _map1 = new Map1();
        }

        public override void End()
        {
            SoundManager.Stop("BGM");
        }
        public override void Draw()
        {

            int y = 0;
            // if (_mario.Top.Y > 500)
            //{
            //    y = 0;
            //}
            //else
            //{
            //    y = 300 - _mario.Top.Y;
            //}

            int x;
            if (400 - _mario.Top.X < 0)
            {
                x = 400 - _mario.Top.X;
            }
            else
            {
                x = 0;
            }
         
            DX.DrawGraph(0,0, backgroundHandle, DX.TRUE);
        
             var p = new Point(x,y);
            _map1.Draw(p);
            _mario.Draw(p);
        }

        public override void Update()
        {
            _mario.Update(_map1);
            _map1.Update(_mario.Point);
        }
    }
}
