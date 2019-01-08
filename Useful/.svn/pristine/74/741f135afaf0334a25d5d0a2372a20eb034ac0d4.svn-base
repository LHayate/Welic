using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace Classes.Uteis
{
    public static class ExportaExcel
    {
        
        ///// <summary>
        ///// Recebe um DataTable e exporta para excel
        ///// </summary>
        ///// <param name="source">DataTable com os registros</param>
        ///// <param name="fileName">Caminho onde deseja salvar os registros</param>
        ///// <param name="fileName">Abrir arquivo ou não.</param>
        //public static void ExportaParaExcel(DataTable source, string fileName, bool open)
        //{
        //    ExportaParaExcel(source, fileName, open, "Plan");
        //}

        public static void ExportaParaExcel(DataTable source, string fileName, bool open, string abaName)
        {
            if (string.IsNullOrEmpty(abaName))
                abaName = "Plan";
            System.IO.StreamWriter excelDoc;

            excelDoc = new System.IO.StreamWriter(fileName);
            const string startExcelXML = "<xml version>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\">\r\n <Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                  "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                  " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
                  "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;

            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"" + abaName + sheetCount + "\">");
            excelDoc.Write("<Table>");
            excelDoc.Write("<Row>");
            for (int x = 0; x < source.Columns.Count; x++)
            {
                excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                excelDoc.Write(source.Columns[x].ColumnName);
                excelDoc.Write("</Data></Cell>");
            }
            excelDoc.Write("</Row>");
            foreach (DataRow x in source.Rows)
            {
                rowCount++;
                //if the number of rows is > 64000 create a new page to continue output
                if (rowCount == 64000)
                {
                    rowCount = 0;
                    sheetCount++;
                    excelDoc.Write("</Table>");
                    excelDoc.Write(" </Worksheet>");
                    excelDoc.Write("<Worksheet ss:Name=\"" + abaName + sheetCount + "\">");
                    excelDoc.Write("<Table>");
                }
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < source.Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                           "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate 
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            string XMLDatetoString = ""; //Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() +
                                 "-" +
                                 (XMLDate.Month < 10 ? "0" +
                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                 "-" +
                                 (XMLDate.Day < 10 ? "0" +
                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                 "T" +
                                 (XMLDate.Hour < 10 ? "0" +
                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                 ":" +
                                 (XMLDate.Minute < 10 ? "0" +
                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                 ":" +
                                 (XMLDate.Second < 10 ? "0" +
                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                 ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                         "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetoString);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                        "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                    "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>");
                            break;
                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>");
            }
            excelDoc.Write("</Table>");
            excelDoc.Write(" </Worksheet>");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
            if (open)
            {
                AbrirExcel(fileName);
            }

        }

        /// <summary>
        /// Abri um Excel
        /// </summary>
        /// <param name="fileName">Passe o endereço do Excel</param>
        public static void AbrirExcel(string fileName)
        {
            string arqExcel = fileName;



            if (arqExcel != "")
            {

                try
                {

                    System.Diagnostics.Process proc = new System.Diagnostics.Process();

                    proc.EnableRaisingEvents = true;

                    proc.StartInfo.FileName = arqExcel;

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

                MessageBox.Show("Informe a localização do arquivo Excel.");

            }

        }

        /// <summary>
        /// Recebe um DataTable e exporta para excel
        /// </summary>
        /// <param name="source">DataTable com os registros</param>
        /// <param name="fileName">Caminho onde deseja salvar os registros</param>
        /// <param name="fileName">Abrir arquivo ou não.</param>
        public static void ExportaParaExcel(DataTable dt, string fileName, bool open)
        {            
            ExportaExcel.ExportaParaExcel(dt, fileName, open, true);

            //SaveFileDialog saveDialog = new SaveFileDialog();

            //if (string.IsNullOrEmpty(fileName))
            //{
            //    saveDialog.DefaultExt = "xls";
            //    saveDialog.Filter = "Microsoft Excel (.xls)|*.xls|Todos Arquivos (*.*)|*.*";
            //    saveDialog.AddExtension = true;
            //    saveDialog.RestoreDirectory = true;
            //    saveDialog.Title = "Onde você deseja salvar o arquivos?";
            //    saveDialog.InitialDirectory = @"C:\Temp";

            //    if (saveDialog.ShowDialog() == DialogResult.OK)
            //        fileName = saveDialog.FileName;
            //}

            //if (!string.IsNullOrEmpty(fileName))
            //{
            //    Microsoft.Office.Interop.Excel.Application excel = null;
            //    Microsoft.Office.Interop.Excel.Workbook wb = null;

            //    object missing = Type.Missing;
            //    Microsoft.Office.Interop.Excel.Worksheet ws = null;
            //    Microsoft.Office.Interop.Excel.Range rng = null;

            //    try
            //    {
            //        excel = new Microsoft.Office.Interop.Excel.Application();
            //        wb = excel.Workbooks.Add();
            //        ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

            //        for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
            //        {
            //            ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
            //        }

            //        for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
            //        {
            //            ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
            //        }

            //        excel.ActiveWorkbook.SaveCopyAs(fileName);
            //        excel.DisplayAlerts = false;
            //        excel.Quit();

            //        if (open == true)
            //            AbrirExcel(fileName);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error accessing Excel: " + ex.ToString());
            //    }
            //}
        }

        public static void ExportaParaExcel(DataTable dt, string fileName, bool open, bool ajustarLarguraColunas)
        {
            ExportaExcel.ExportaParaExcel(dt, fileName, open, ajustarLarguraColunas, null, null, null );
        }

        public static void ExportaParaExcelSubTotal(DataTable dt, string fileName, bool open, bool ajustarLarguraColunas, int pColunaAgrupar,
                                                    Microsoft.Office.Interop.Excel.XlConsolidationFunction pFuncaoAgrupadora)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (string.IsNullOrEmpty(fileName))
            {
                saveDialog.DefaultExt = "xlsx";
                saveDialog.Filter = "Microsoft Excel (.xlsx)|*.xlsx|Todos Arquivos (*.*)|*.*";
                saveDialog.AddExtension = true;
                saveDialog.RestoreDirectory = true;
                saveDialog.Title = "Onde você deseja salvar o arquivos?";
                saveDialog.InitialDirectory = @"C:\Temp";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                    fileName = saveDialog.FileName;
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                Microsoft.Office.Interop.Excel.Application excel = null;
                Microsoft.Office.Interop.Excel.Workbook wb = null;

                object missing = Type.Missing;
                Microsoft.Office.Interop.Excel.Worksheet ws = null;
                Microsoft.Office.Interop.Excel.Range rng = null;

                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    wb = excel.Workbooks.Add();
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

                    for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                    {
                        ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                    }

                    for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                    {
                        ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
                    }

                    if (ajustarLarguraColunas)
                        for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                        {
                            ws.Range["A1"].Offset[0, Idx].EntireColumn.AutoFit();
                        }

                    rng = ws.Range["A1", Type.Missing];
                    int[] colunas = new int[]{2,3};
                    rng.Subtotal(pColunaAgrupar, pFuncaoAgrupadora, colunas, false, false, Microsoft.Office.Interop.Excel.XlSummaryRow.xlSummaryAbove);
                    
                    excel.ActiveWorkbook.SaveCopyAs(fileName);
                    excel.DisplayAlerts = false;
                    excel.Quit();

                    if (open == true)
                        AbrirExcel(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accessing Excel: " + ex.ToString());
                }
            }
        }


        public static void ExportaParaExcel(DataTable dt, string fileName, bool open, bool ajustarLarguraColunas, string codigo, string descricao, string titulo)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            bool extrator = false;

            if (string.IsNullOrEmpty(fileName))
            {
                saveDialog.DefaultExt = "xlsx";
                saveDialog.Filter = "Microsoft Excel (.xlsx)|*.xlsx|Todos Arquivos (*.*)|*.*";
                saveDialog.AddExtension = true;
                saveDialog.RestoreDirectory = true;
                saveDialog.Title = "Onde você deseja salvar o arquivos?";
                saveDialog.InitialDirectory = @"C:\Temp";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                    fileName = saveDialog.FileName;
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                Microsoft.Office.Interop.Excel.Application excel = null;
                Microsoft.Office.Interop.Excel.Workbook wb = null;

                object missing = Type.Missing;
                Microsoft.Office.Interop.Excel.Worksheet ws = null;
                Microsoft.Office.Interop.Excel.Range rng = null;
                try
                {

                    excel = new Microsoft.Office.Interop.Excel.Application();
                    wb = excel.Workbooks.Add();
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

                    if (!string.IsNullOrEmpty(codigo) && !string.IsNullOrEmpty(descricao))
                    {
                        ws.Range["A1"].Offset[0, 0].Value = "Comando: " ;
                        ws.Range["A1"].Offset[0, 1].Value = codigo;
                        ws.Range["B1"].Offset[0, 1].Value = descricao;
                        extrator = true; 
                    }

                    if (!string.IsNullOrEmpty(titulo))
                    {
                        ws.Range["A1"].Offset[0, 1].Value = titulo;
                        extrator = true;
                    }

                    for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                    {
                        if (extrator)
                        {
                            ws.Range["A3"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                        }
                        else
                        {
                            ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                        }
                    }

                    for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                    {
                        if (extrator)
                        {
                            ws.Range["A4"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
                        }
                        else
                        {
                            ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
                        }
                    }

                    if (ajustarLarguraColunas)
                        for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                        {
                            ws.Range["A1"].Offset[0, Idx].EntireColumn.AutoFit();
                        }

                    excel.ActiveWorkbook.SaveCopyAs(fileName);
                    excel.DisplayAlerts = false;
                    excel.Quit();

                    if (open == true)
                        AbrirExcel(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accessing Excel: " + ex.ToString());
                }
            }
        }


        public static void ExportaParaExcel(DataTable dt, string fileName, bool open, bool ajustarLarguraColunas, string titulo)
        {
            ExportaExcel.ExportaParaExcel(dt, fileName, open, ajustarLarguraColunas, null, null, titulo);
        }
        

    }
}
