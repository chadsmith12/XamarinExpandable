using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExpandableTest.Models
{
    public class ObservableGroup<TK, T> : ObservableCollection<T>
    {
        public TK Key { get; }

        public ObservableGroup(TK key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
