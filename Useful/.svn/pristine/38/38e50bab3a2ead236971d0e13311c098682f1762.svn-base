using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Classes.Uteis
{
    public static class ImprimeLPT1
    {
        const Int32 GENERIC_WRITE = 1073741824;
        const Int32 OPEN_EXISTING = 3;
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);

        private static StreamWriter GetStreamWriter(string port)
        {
            IntPtr hFich = CreateFile(port, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            FileStream stream = new FileStream(hFich, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            return writer;
        }
        /// <summary>
        /// Imprime texto via LPT1
        /// </summary>
        /// <param name="texto">Texto que irá ser impresso</param>
        public static void ImprimirLPT1(string texto)
        {
            StreamWriter lpt1 = GetStreamWriter("LPT1");
            lpt1.WriteLine(texto);
            // Espaço para cortar o papel
            lpt1.WriteLine("\n");
            lpt1.WriteLine("\n");
            lpt1.WriteLine("\n");
            lpt1.WriteLine("\n");
            lpt1.Close();
        }
    }
}
