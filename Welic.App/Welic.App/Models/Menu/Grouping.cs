using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Welic.App.Models.Menu
{
    public class Grouping<TK,T> : ObservableCollection<T>
    {
        public TK Key { get; }

        public Grouping(TK key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                Add(item);
        }
        public Grouping(TK key)
        {
            Key = key;                       
        }
    }
}
