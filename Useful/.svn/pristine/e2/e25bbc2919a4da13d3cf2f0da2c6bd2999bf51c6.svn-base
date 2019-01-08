using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Classes.Uteis
{
    public static class ImportaExcel
    {
        /// <summary>
        /// Recebe o caminho do arquivo e o nome da Planilha excel e retorna em um datatable
        /// </summary>
        /// <param name="Path">Caminho do Arquivo</param>
        /// <param name="PlanName">Nome da Planilha</param>        
        public static DataTable ImportaExel(string Path, string PlanName)
        {
            string cnnString = string.Empty;
            if (Path.Substring(Path.Length - 1, 1).ToUpper() == "X")
                cnnString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES';", Path);
            else
                cnnString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;""", Path);
            
            string sql = "select * from [{0}$]";
            System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(cnnString);
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(String.Format(sql, PlanName), cnn);
            DataSet ds = new DataSet();
            var dt = new DataTable();
            try
            {
                cnn.Open();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
                da.Dispose();
                ds.Dispose();
            }
            return dt;
        }   

    }
}
