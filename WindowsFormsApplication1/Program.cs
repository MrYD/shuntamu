﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

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
            
            square floor=new square(new Size(0,500), new Size(800,100));
            Mario mario=new Mario();
            var DrawableList=new List<DrawableObject>();
            DrawableList.Add(floor);
            DrawableList.Add(mario);
            var World=new List<square>();
            World.Add(floor);

            while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
            {
                //DX.DrawString(400, 300, "hello World", DX.GetColor(255, 255, 255));
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
