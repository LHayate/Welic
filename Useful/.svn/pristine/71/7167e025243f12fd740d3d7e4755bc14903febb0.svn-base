using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Classes.Uteis
{
    public static class CriaArquivoTxt
    {
        public static void CriarTxt(string caminho, string arquivo, string nomeArquivo, bool showArquivo)
        {
            if (string.IsNullOrEmpty(caminho))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = @"C:\";
                saveFileDialog.Title = "Local onde deseja salvar o arquivo";
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.FileName = nomeArquivo;
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Filter = "(*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    caminho = saveFileDialog.FileName;
                    StreamWriter sw = new StreamWriter(caminho);
                    sw.Write(arquivo.ToString());
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(caminho);
                sw.Write(arquivo.ToString());
                sw.Close();
            }
            if (showArquivo && !string.IsNullOrEmpty(caminho))
            {
                System.Diagnostics.Process.Start(caminho);
            }
        }

        public static void CriarTxt(string arquivo, string nomeArquivo, bool showArquivo)
        {
            CriarTxt(string.Empty, arquivo, nomeArquivo, showArquivo);
        }

        public static void CriarTxt(string arquivo, string nomeArquivo)
        {
            CriarTxt(string.Empty, arquivo, nomeArquivo, false);
        }
    }
}
