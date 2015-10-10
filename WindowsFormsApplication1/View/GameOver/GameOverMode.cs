using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.GameOver
{
    class GameOverMode:ModeBase
    {
        private int handle = DX.LoadGraph(@"IWBT素材\スプライト\ガメオベラ.png");
        public override void Draw()
        {
            DX.DrawGraph(0, 150, handle, DX.FALSE);
        }

        public override void Update()
        {
           
        }
    }
}
