using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UseFul.Uteis
{
    public static class ValidaStringNumero
    {
        public static bool ValidaNumero(string numero)
        {
            Regex rx = new Regex(@"^\d+$");
            return rx.IsMatch(numero);
        }
    }
}
