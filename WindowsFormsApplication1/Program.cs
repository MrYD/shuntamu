using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;
using shuntamu.Util;
using shuntamu.View;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            DX.ChangeWindowMode(DX.TRUE);
            DX.SetGraphMode(800, 600, 32);
            if (DX.DxLib_Init() == -1) return;
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            
            Square floor=new Square(new Size(0,500), new Size(800,100));
            MainCharactor mario=new MainCharactor();
            var DrawableList=new List<IDrawable>();
            DrawableList.Add(floor);
            DrawableList.Add(mario);
            var World=new List<Square>();
            World.Add(floor);

            while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
            {
                //DX.DrawString(400, 300, "hello World", DX.GetColor(255, 255, 255));
                if (Input.Instance.Right)
                mario.Updata(World);
                foreach (var Obj in DrawableList)
                {
                    Obj.Draw();
                }
            }
            DX.DxLib_End();
        }
    }
}
