using System.Drawing;
using System.Drawing.Text;
using DxLibDLL;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class GameMode1 : ModeBase
    {
        private readonly Map1 _map1;
        private readonly MainCharactor _mario;
        int backgroundHandle = DX.LoadGraph(@"../../IWBT素材/背景/夜_トランジション.png");
        private int bgmHandle = DX.LoadSoundMem(@"../../IWBT素材/音源/bgm_loop_103.wav");
        public GameMode1()
        {
            DX.ChangeVolumeSoundMem(80, bgmHandle);
            DX.PlaySoundMem(bgmHandle, DX.DX_PLAYTYPE_LOOP);
       
            _mario = new MainCharactor();
            _map1 = new Map1();
        }

        public override void Draw()
        {

            int y;
            if (_mario.Top.Y > 500)
            {
                y = 0;
            }
            else
            {
                y = 300 - _mario.Top.Y;
            }

         
            DX.DrawGraph(0,0, backgroundHandle, DX.TRUE);
        
             var p = new Point(400-_mario.Top.X,y);
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
