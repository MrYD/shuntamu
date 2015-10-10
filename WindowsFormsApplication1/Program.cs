using System;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DX.ChangeWindowMode(DX.TRUE);
            DX.SetGraphMode(800, 600, 32);
            if (DX.DxLib_Init() == -1) return;
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            var view = new View.View();

            while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
            {
                view.Update();
                view.Draw();
                Input.Instance.Update();
            }
            DX.DxLib_End();
        }
    }
}
