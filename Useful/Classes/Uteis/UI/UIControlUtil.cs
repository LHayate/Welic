using System;
using System.Windows.Forms;

namespace UseFul.Uteis.UI
{
    public class UiControlUtil
    {
        public static void ProcessMessage(string message, MessageType type)
        {
            

            switch (type)
            {
                case MessageType.Error:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case MessageType.Information:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageType.Warning:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                default:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }            

            AppLogging.Log(message, LogType.Info);
        }

        public static void ProcessMessage(string message, string exceptionMessage, MessageType type)
        {
            switch (type)
            {
                case MessageType.Error:
                    MessageBox.Show(
                        $"{message}{Environment.NewLine}|{Environment.NewLine}|-> {exceptionMessage}", "Welic",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Information:
                    MessageBox.Show(
                        $"{message}{Environment.NewLine}|{Environment.NewLine}|-> {exceptionMessage}", "Welic",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageType.Warning:
                    MessageBox.Show(
                        $"{message}{Environment.NewLine}|{Environment.NewLine}|-> {exceptionMessage}", "Welic",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                default:
                    MessageBox.Show(
                        $"{message}{Environment.NewLine}|{Environment.NewLine}|-> {exceptionMessage}", "Welic",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }            
        }

        public static Result ProcessDialog(string message,
            MessageBoxButtons buttons = MessageBoxButtons.YesNo)
        {
            DialogResult dr = MessageBox.Show(message, "Welic", buttons, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return Result.No;
            }
            return dr == DialogResult.Yes ? Result.Yes : Result.Cancel;
        }

        public static Result ProcessStaticDialog(string message, MessageBoxButtons buttons)
        {
            DialogResult dr = MessageBox.Show(message, "Welic", buttons, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return Result.No;
            }
            return dr == DialogResult.Yes ? Result.Yes : Result.Cancel;
        }

        public static void ProcessStaticMessage(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Error:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Information:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageType.Warning:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                default:
                    MessageBox.Show(message, "Welic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            
            AppLogging.Log(message, LogType.Info);
        }

        public static void DisposeForm(Form form)
        {
            form.Controls.Clear();
            form.Dispose();
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Optimized);
        }

        public static void ProcessException(IWin32Window parent, Exception ex)
        {
            StopWaitCursor();
            AppLogging.LogException(ex.Message, ex, LogType.Error);

            string mensagemAdicional = ex.InnerException?.Message ?? string.Empty;
            string mensagem = ex.Message;

            if (mensagem != string.Empty)
            {
                mensagem = mensagem + $" -> {mensagemAdicional}";
            }

            ProcessMessage("Ocorreu uma falha no Sistema.", mensagem, MessageType.Error);
        }

        public static void StartWaitCursor()
        {
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void StopWaitCursor()
        {
            Cursor.Current = Cursors.Default;
        }
    }
}