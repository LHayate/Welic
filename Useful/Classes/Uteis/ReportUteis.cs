using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace UseFul.Uteis
{


    public class ReportViewerMensagens : IReportViewerMessages
    {

        #region IReportViewerMessages Members

        public string BackButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string BackMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string ChangeCredentialsText

        {

        get { return ("Tradução"); }

        }

        public string CurrentPageTextBoxToolTip

        {

        get { return ("Tradução"); }

        }

        public string DocumentMapButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string DocumentMapMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string ExportButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string ExportMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string FalseValueText

        {

        get { return ("Tradução"); }

        }

        public string FindButtonText

        {

        get { return ("Tradução"); }

        }

        public string FindButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string FindNextButtonText

        {

        get { return ("Tradução"); }

        }

        public string FindNextButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string FirstPageButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string LastPageButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string NextPageButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string NoMoreMatches

        {

        get { return ("Tradução"); }

        }

        public string NullCheckBoxText

        {

        get { return ("Tradução"); }

        }

        public string NullCheckBoxToolTip

        {

        get { return ("Tradução"); }

        }

        public string NullValueText

        {

        get { return ("Tradução"); }

        }

        public string PageOf

        {

        get { return ("Tradução"); }

        }

        public string PageSetupButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string PageSetupMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string ParameterAreaButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string PasswordPrompt

        {

        get { return ("Tradução"); }

        }

        public string PreviousPageButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string PrintButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string PrintLayoutButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string PrintLayoutMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string PrintMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string ProgressText

        {

        get { return ("Gerando Relatório … "); }

        }

        public string RefreshButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string RefreshMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string SearchTextBoxToolTip

        {

        get { return ("Tradução"); }

        }

        public string SelectAValue

        {

        get { return ("Tradução"); }

        }

        public string SelectAll

        {

        get { return ("Tradução"); }

        }

        public string StopButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string StopMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string TextNotFound

        {

        get { return ("Tradução"); }

        }

        public string TotalPagesToolTip

        {

        get { return ("Tradução"); }

        }

        public string TrueValueText

        {

        get { return ("Tradução"); }

        }

        public string UserNamePrompt

        {

        get { return ("Tradução"); }

        }

        public string ViewReportButtonText

        {

        get { return ("Tradução"); }

        }

        public string ViewReportButtonToolTip

        {

        get { return ("Tradução"); }

        }

        public string ZoomControlToolTip

        {

        get { return ("Tradução"); }

        }

        public string ZoomMenuItemText

        {

        get { return ("Tradução"); }

        }

        public string ZoomToPageWidth

        {

        get { return ("Tradução"); }

        }

        public string ZoomToWholePage

        {

        get { return ("Tradução"); }

        }

#endregion

    }

    public class ReportUteis
    {
        public enum rptFormat
        {
            Excel,
            PDF,
            Image,
        }

        private rptFormat _tipoExportacao;

        public rptFormat TipoExportacao
        {
            get { return _tipoExportacao; }
            set { _tipoExportacao = value; }
        }

        public void ExportarReport(LocalReport report, rptFormat rptFormat, string filePath)
        {
            Warning[] warnings = null;
            string[] streamids = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;

            byte[] bytes = report.Render(rptFormat.ToString(), null, out mimeType, out encoding, out extension, out streamids, out warnings);

            switch (rptFormat)
            {
                case rptFormat.Excel:
                    filePath = Path.ChangeExtension(filePath, "xls");
                    break;
                case rptFormat.Image:
                    filePath = Path.ChangeExtension(filePath, "jpg");
                    break;
                case rptFormat.PDF:
                    filePath = Path.ChangeExtension(filePath, "pdf");
                    break;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

            bytes = null;
        }
    }
}
