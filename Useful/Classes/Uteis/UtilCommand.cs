using System.Diagnostics;

namespace UseFul.Uteis
{
    public class UtilCommand
    {
        public static void OpenFile(string fullPathFile)
        {
            Process.Start(fullPathFile);
        }
    }
}