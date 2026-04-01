using System;
using System.Windows.Forms;

namespace MyBMICalculator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 這一行就是叫程式啟動時打開 Form1 視窗
            Application.Run(new Form1());
        }
    }
}