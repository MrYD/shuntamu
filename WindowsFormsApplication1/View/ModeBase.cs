using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View
{
    /// <summary>
    /// ゲームモード の 基底クラス
    /// </summary>
    abstract class ModeBase
    {
        public abstract void Draw();

        public abstract void Update();
    }
}
