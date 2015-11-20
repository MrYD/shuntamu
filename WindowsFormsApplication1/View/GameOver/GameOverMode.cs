using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.GameOver
{
    class GameOverMode:ModeBase
    {
        private int handle = DX.LoadGraph(@"../../IWBT素材/スプライト/gameOver.png");
        public override void Draw()
        {
            DX.DrawGraph(0, 0, handle, DX.TRUE);
        }

        public override void Update()
        {
            if (Input.Instance.Space)
            {
                View.Reset();
            }
        }
    }
}
