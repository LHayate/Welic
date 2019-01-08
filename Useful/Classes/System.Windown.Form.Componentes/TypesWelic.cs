using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseFul.Forms.Welic
{
    public class Intervalo
    {
        public object _Min;
        public object _Max;

        public Intervalo(object min, object max)
        {
            this._Min = min;
            this._Max = max;
        }
    }
    
    /// <summary>
    /// Like Ini = 'CONDIÇÃO%' - Começa com
    /// Like Fim = '%CONDIÇÃO' - Termina com
    /// Like = '%CONDIÇÃO%' - Contém
    /// </summary>
    public enum WhereOptions { ListIn, ListNotIn, WherePersonalizado, Like, LikeIni, LikeFim }
    public class Where
    {
        public string _CustomClause { get; set; }
        public string _Column { get; set; }
        public object _Parameter { get; set; }
        public string _List { get; set; }
        public WhereOptions? _Option { get; set; }
    }
}
