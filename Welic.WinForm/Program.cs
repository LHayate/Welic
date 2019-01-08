using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseFul.Forms.Welic;
using UseFul.Uteis;

namespace Welic.WinForm
{
    static class Program
    {
        public static FrmLogin LoginForm;
        public static Principal MainForm;

        public static readonly string VersaoSistema = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            CustomException exception = new CustomException();
            Application.ThreadException += exception.Application_ThreadException;
            MainForm = new Principal();
            LoginForm = new FrmLogin();
            Application.EnableVisualStyles();
            

            LoginForm.ShowDialog();
            Application.Run();
        }
    }
}
