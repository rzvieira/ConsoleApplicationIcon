using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ConsoleApplicationIcon
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread]
        static void Main()
        {
            //Hide the window                    
            IntPtr hWnd = FindWindow(null, Console.Title);
            ShowWindow(hWnd, 0); // 0 = SW_HIDE    

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyApplicationContext());
        }
    }
}
