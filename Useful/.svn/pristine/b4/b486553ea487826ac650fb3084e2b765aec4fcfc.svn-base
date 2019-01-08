using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classes.Entity;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Runtime.InteropServices;

namespace Classes.Uteis
{
    public static class Arquivos
    {
        public static int GetQuantidadePaginasPDF(string caminhoPDF)
        {
            PdfReader pdfReader = new PdfReader(caminhoPDF);
            int qtdPaginas = pdfReader.NumberOfPages;
            pdfReader.Dispose();
            return qtdPaginas;
        }
        public static void UnificarPDFs(string[] fileNames, string outFile)
        {
            int pageOffset = 0;
            int f = 0;
            Document document = null;
            PdfCopy writer = null;
            while (f < fileNames.Length)
            {
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(fileNames[f]);
                reader.ConsolidateNamedDestinations();
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;
                pageOffset += n;
                if (f == 0)
                {
                    // step 1: creation of a document-object
                    document = new Document(reader.GetPageSizeWithRotation(1));
                    // step 2: we create a writer that listens to the document
                    writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
                    // step 3: we open the document
                    document.Open();
                }
                // step 4: we add content
                for (int i = 0; i < n; )
                {
                    ++i;
                    if (writer != null)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        writer.AddPage(page);
                        page = null;
                    }
                }

                f++;
                reader.Dispose();
            }

            // step 5: we close the document
            document.Dispose();
            writer.Dispose();
            document = null;
            writer = null;
            GC.Collect();
        }
        public static byte[] CarregarArquivo(string caminho)
        {
            long tamanhoDocumento = 0;
            byte[] docEmBytes = null;
            FileInfo documento = new FileInfo(caminho);
            tamanhoDocumento = documento.Length;
            docEmBytes = new byte[Convert.ToInt32(tamanhoDocumento)];
            FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.Read);
            fs.Read(docEmBytes, 0, Convert.ToInt32(tamanhoDocumento));
            fs.Close();
            fs.Dispose();
            return docEmBytes;
        }
        public static void AbrirArquivo(string caminho)
        {
            if (caminho != "")
            {
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = true;
                    proc.StartInfo.FileName = caminho;
                    proc.Start();
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("Diretório não encontrado !");
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Arquivo não encontrado !");
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Arquivo não esta disponível. Pode estar em uso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Houve um problema ao abrir o arquivo :" + ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Informe a localização do arquivo!");
            }
        }
        public static void GerarArquivo(byte[] arquivo, string caminho)
        {
            FileStream fs = new FileStream(caminho, FileMode.Create, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(arquivo);
            fs.Close();
            fs.Dispose();
        }
        public static void ConverterWordParaPDF(string caminhoOrigemArquivoWord, string caminhoDestinoArquivoPdf)
        {
            // Abrir Aplicacao Word
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            // Arquivo de Origem
            object _caminhoArquivoDoc = caminhoOrigemArquivoWord;
            object _caminhoArquivoPdf = caminhoDestinoArquivoPdf;

            object missing = System.Type.Missing;

            // Abrir documento
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref _caminhoArquivoDoc, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);

            // Formato para Salvar o Arquivo – Destino  - No caso, PDF
            object formatoArquivo = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;

            // Salvar Arquivo
            doc.SaveAs(ref _caminhoArquivoPdf, ref formatoArquivo, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            // Não salvar alterações no arquivo original
            object salvarAlteracoesArqOriginal = false;
            wordApp.Quit(ref salvarAlteracoesArqOriginal, ref missing, ref missing);
        }
        public static byte[] AddPageNumbers(byte[] pdf)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(pdf, 0, pdf.Length);
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(pdf);
            // we retrieve the total number of pages
            int n = reader.NumberOfPages;
            // we retrieve the size of the first page
            Rectangle psize = reader.GetPageSize(1);

            // step 1: creation of a document-object
            Document document = new Document(psize, 50, 50, 50, 50);
            // step 2: we create a writer that listens to the document
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            // step 3: we open the document

            document.Open();
            // step 4: we add content
            PdfContentByte cb = writer.DirectContent;

            int p = 0;
            //Console.WriteLine("There are " + n + " pages in the document.");
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                document.NewPage();
                p++;

                PdfImportedPage importedPage = writer.GetImportedPage(reader, page);
                cb.AddTemplate(importedPage, 0, 0);

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Página " + p + " de " + n, 50, 44, 0);
                cb.EndText();
            }
            // step 5: we close the document
            document.Close();
            return ms.ToArray();
        }

        [DllImport("shell32.dll", EntryPoint = "ShellExecute")]
        public static extern int ExecutarShell(int hwnd, string lpOperacao,
              string lpArquivo, string lpParametros, string lpDiretorio, int lpMostraCmd);        
    }
}
