using System;
using System.Threading;
using System.Windows.Forms;

namespace UseFul.Uteis
{
    public class CustomException : ApplicationException
    {
        public CustomException()
        {
            Inner = InnerException;
        }

        public CustomException(string message)
            : base(message)
        {
            Inner = InnerException;
        }

        public Exception Inner { get; set; }
        public string Parameter { get; set; }

        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                ShowThreadExceptionDialog(e.Exception, "Welic Erro", null);
                AppLogging.LogException(e.Exception.Message, e.Exception, LogType.Error);
            }
            catch (Exception exception)
            {
                //RadMessageBox.Show("Ocorreu um erro inesperado. Entre em contato com o administrador do Sistema", "Welic",
                //MessageBoxButtons.OK, RadMessageIcon.Error);
                AppLogging.LogException(e.Exception.Message, exception, LogType.Error);
            }
        }

        public static void ShowThreadExceptionDialog(Exception ex, string parentMessage, IWin32Window parent)
        {
            //RadMessageBox.Show("Ocorreu um erro inesperado. Entre em contato com o administrador do Sistema", "Welic",
            //    MessageBoxButtons.OK, RadMessageIcon.Error);
            AppLogging.LogException(ex.Message, ex, LogType.Error);
        }
    }
}