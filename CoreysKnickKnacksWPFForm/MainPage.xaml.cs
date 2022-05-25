using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CoreysKnickKnacksWPFForm
{
    
    public partial class Window1 : Window
    {
    private IStore _Store;
    public ObservableCollection<StoreItem> _Items { get; private set; }
        public Window1(Store store)
        {
            InitializeComponent();
            //_Store = store;
            _Store = store;
            _Items = new ObservableCollection<StoreItem>();
            lbInventoryList.ItemsSource = _Items;
            RefreshList();
            
        }

        private void RefreshList()
        {
            _Items.Clear();
            foreach (StoreItem si in new ObservableCollection<StoreItem>(_Store.GetStoreItems())) _Items.Add(si);
        }

        private void MainPageAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow();
            mainFrame.Navigate(addItemWindow.ShowDialog());

            if (addItemWindow.DialogResult == true)
            {
                _Store.AddStoreItem(addItemWindow.Item.Product, addItemWindow.Item.Quantity);
                RefreshList();
            }

        }

        private void removeAllItems_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem removeItemWindow = new RemoveItem();
            mainFrame.Navigate(removeItemWindow.ShowDialog());
            foreach (StoreItem si in _Items)
            {
                removeItemWindow.removeItemComboBox.Items.Add(si);
            }
        }
    }
}
