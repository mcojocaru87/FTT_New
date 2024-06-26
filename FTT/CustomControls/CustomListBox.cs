using System.Collections.Specialized;
using System.ComponentModel;

namespace FTT.CustomControls
{
    public class CustomListBox : ListBox
    {
        public event EventHandler? ItemAdded;

        private object? dataSource;

        public new object DataSource
        {
            get { return dataSource!; }
            set
            {
                if (dataSource != value)
                {
                    if (dataSource is INotifyCollectionChanged oldNotifySource)
                    {
                        oldNotifySource.CollectionChanged -= OnDataSourceCollectionChanged!;
                    }
                    if (dataSource is IBindingList oldBindingSource)
                    {
                        oldBindingSource.ListChanged -= OnDataSourceListChanged!;
                    }

                    dataSource = value;
                    base.DataSource = dataSource;

                    if (dataSource is INotifyCollectionChanged newNotifySource)
                    {
                        newNotifySource.CollectionChanged += OnDataSourceCollectionChanged!;
                    }
                    if (dataSource is IBindingList newBindingSource)
                    {
                        newBindingSource.ListChanged += OnDataSourceListChanged!;
                    }
                }
            }
        }

        private void OnDataSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                OnItemAdded(EventArgs.Empty);
            }
        }

        private void OnDataSourceListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                OnItemAdded(EventArgs.Empty);
            }
        }

        protected virtual void OnItemAdded(EventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }
    }
}
