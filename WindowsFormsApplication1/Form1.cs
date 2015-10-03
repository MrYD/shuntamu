using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

namespace shuntamu
{
    public partial class Form1 : Form
    {
        private int _frame;
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(800, 600);
            DX.SetUserWindow(Handle);
            DX.DxLib_Init();
            Task.Factory.StartNew(() =>
            {
                while (DX.ProcessMessage() == 0)
                {

                    DX.ClearDrawScreen();
                    Mainloop();
                    _frame++;
                    DX.ScreenFlip();
                }
            });
        }

        private void Mainloop()
        {
            DX.DrawBox(0+_frame, 0, 100+_frame, 100, DX.GetColor(200, 0, 0), DX.TRUE);
        }
    }
}
