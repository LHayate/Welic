using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classes.Uteis
{
    public static class ConverteDocumentoWordPDF
    {
        /// <summary>
        /// Metodo para converte o Documento do Word em PDF -Esse metodo utiliza o 
        /// Open File Dialog para busca o documento
        /// Save File Dialog para salvar o documento
        /// </summary>

        public static void ConverteDoc()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GerarArquivoPdf(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Metodo para converte o Documento do Word em PDF -Esse metodo utiliza o 
        /// os paramestros com os caminhos passados para salvar abrir e salvar no local determinado
        /// </summary>
        /// <param name="caminhoDoc">Caminho onde se encontra o documento do Word</param>
        /// <param name="caminhoPDF">Caminho vai salvar o PDF</param>

        public static void ConverteDoc(string caminhoDoc, string caminhoPDF, bool abrirPDF)
        {
            GerarArquivoPdf(caminhoDoc, caminhoPDF, abrirPDF);
        }

        private static void GerarArquivoPdf(string caminhoDoc, string caminhoPDF, bool abrirPDF)
        {
            try
            {
                // Abrir Aplicacao Word
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // Arquivo de Origem
                object filename = caminhoDoc;

                object newFileName = caminhoPDF;

                object missing = System.Type.Missing;

                // Abrir documento
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

                // Formato para Salvar o Arquivo – Destino  - No caso, PDF
                object formatoArquivo = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;

                // Salvar Arquivo
                doc.SaveAs(ref newFileName, ref formatoArquivo, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                // Não salvar alterações no arquivo original
                object salvarAlteracoesArqOriginal = false;
                wordApp.Quit(ref salvarAlteracoesArqOriginal, ref missing, ref missing);

                if (abrirPDF == true)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = true;
                    proc.StartInfo.FileName = caminhoPDF + ".pdf";
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar documento. Motivo: \n" + ex.Message, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void GerarArquivoPdf(string caminhoDoc)
        {
            try
            {
                // Abrir Aplicacao Word
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // Arquivo de Origem
                object filename = caminhoDoc;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.ShowDialog();

                // Verifica se ´nome do Arquivo esta vazio
                if (string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    object newFileName = saveFileDialog1.FileName;;

                    object missing = System.Type.Missing;

                    // Abrir documento
                    Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing);

                    // Formato para Salvar o Arquivo – Destino - No caso, PDF
                    object formatoArquivo = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;

                    // Salvar Arquivo
                    doc.SaveAs(ref newFileName, ref formatoArquivo, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                    // Não salvar alterações no arquivo original
                    object salvarAlteracoesArqOriginal = false;
                    wordApp.Quit(ref salvarAlteracoesArqOriginal, ref missing, ref missing);

                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = true;
                    proc.StartInfo.FileName = saveFileDialog1.FileName + ".pdf";
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar documento. Motivo: \n" + ex.Message, "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
