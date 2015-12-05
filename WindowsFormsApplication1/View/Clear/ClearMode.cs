using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.Clear
{
    internal class ClearMode:ModeBase

{
        private int handle = DX.LoadGraph(@"../../IWBT素材/スプライト/clearObject.png");
    public override void Draw()
    {
        Init();
    }

    public override void Update()
    {
        if (Input.Instance.Space)
        {
            View.Reset();
        }
    }

        public override void Init()
        {
            DX.DrawGraph(0, 120, handle, DX.FALSE);
        }

        public override void End()
        {
          
        }
}
}
