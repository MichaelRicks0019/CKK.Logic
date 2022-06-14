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
using CKK.Logic.Exceptions;
using CKK.Persistance.Interfaces;
using CKK.Persistance.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Win32;

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

        private void RemoveAllItems_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem removeItemWindow = new RemoveItem();
            removeItemWindow.removeItemComboBox.ItemsSource = _Items;
            mainFrame.Navigate(removeItemWindow.ShowDialog());

            if(removeItemWindow.DialogResult == true)
            {
                _Store.RemoveStoreItem(removeItemWindow.IdPH, removeItemWindow.Quantity);
                RefreshList();
            }
    
        }

        private void ViewAllItems_Click(object sender, RoutedEventArgs e)
        {
            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = _Items;
            mainFrame.Navigate(viewAllItemsWindow.ShowDialog());
        }

        private void SaveItems_Click(object sender, RoutedEventArgs e)
        {
            FileStore fs = new FileStore();
            foreach(StoreItem si in _Items)
            {
                fs.AddStoreItem(si.GetProduct(), si.GetQuantity());
            }
            fs.Save();
            //Random beep for the fun of it
            Console.Beep();
        }

        private void LoadItems_CLick(object sender, RoutedEventArgs e)
        {
            FileStore fs = new FileStore();
            fs.Load();
            _Items.Clear();
            foreach(StoreItem si in fs.GetStoreItems())
            {
                _Items.Add(si);
            }
            
        }
    }
}
