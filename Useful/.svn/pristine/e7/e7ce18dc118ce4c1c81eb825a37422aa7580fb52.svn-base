using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Classes.Uteis
{
    public static class VerificacaoSistema
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        public static bool ProcessoEstaAberto(Process processo)
        {
            // Buscando o nome do Processo em Execução
            Process[] processos = Process.GetProcessesByName(processo.ProcessName);

            // Verificando se foi encontrado o processo em execução
            if (processos.Length > 1)
            {
                SetForegroundWindow(processos[processos[0].Id == processo.Id ? 1 : 0].MainWindowHandle);
                ShowWindow(processos[processos[0].Id == processo.Id ? 1 : 0].MainWindowHandle, 9);

                processo.Kill();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
