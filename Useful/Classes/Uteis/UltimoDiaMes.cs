using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseFul.Uteis
{
    public static class UltimoDiaMes
    {
        public static DateTime RetornaDia(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
        }
    }
}
