using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Controls
{
    public class CustomCollection<T> : ObservableCollection<T>
    {
        public CustomCollection(IEnumerable<T> list)
        { 
            AddRange(list);
        }

        public CustomCollection()
        {
        }

        public void ReportItemChange(T item)
        {
            NotifyCollectionChangedEventArgs args =
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Replace,
                    item,
                    item,
                    IndexOf(item));
            OnCollectionChanged(args);
        }

        private bool _suppressNotification = false;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (!_suppressNotification)
                    base.OnCollectionChanged(e);
            }
            catch
            {

            }
           
        }

        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            _suppressNotification = true;

            foreach (T item in list)
            {
                Add(item);
            }
            _suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
