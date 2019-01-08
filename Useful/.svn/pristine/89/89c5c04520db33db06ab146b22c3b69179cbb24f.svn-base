using System;
using System.Data;
using System.Text;
using Classes.Dal;
using Classes.Entity;

namespace Classes.Uteis
{
    // Classe para verificar se um dia é útil ou não.
    public static class DiaUtil
    {
       // Método para fazer a verificação se o dia é sábado, domingo ou feriado
        public static bool diaUtil(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
                return false;
            }
            else if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else if (Feriado(dt) == true)
            {
                return false;
            }
            else return true;
        }        
        // Método responsável por verificar se o dia é feriado.
        public static bool Feriado(DateTime dt)
        {
            Conexao dal = new Conexao(Globals.GetStringConnection(), 2);
            DataTable dtDados = new DataTable();

            StringBuilder sql = new StringBuilder();
            
            dal.AddParam("dt", dt);

            sql.Append("SELECT COUNT(DATA) AS TOTAL FROM SGA.FERIADOS WHERE DATA = :dt");
            dtDados = dal.ExecuteQuery(sql.ToString());

            if (int.Parse(dtDados.Rows[0]["TOTAL"].ToString()) > 0)
                return true;
            else
                return false;
        }
        // Método responsável por verificar qual o próximo dia útil.
        public static DateTime ProxDiaUtil(DateTime dt)
        {
            if (diaUtil(dt) == false)
            {
                dt = dt.AddDays(1);
                return ProxDiaUtil(dt);
            }
             else
                return dt;


        }

    }
}
