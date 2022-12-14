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
using CKK.DB.UOW;
using System.Data;
using CKK.DB.Interfaces;

namespace CoreysKnickKnacksWPFForm
{
    
    public partial class Window1 : Window
    {
        UnitOfWork UOW;
        IConnectionFactory conn = new DatabaseConnectionFactory();
        public Window1()
        {
            InitializeComponent();
            UOW = new UnitOfWork(conn);
            lbInventoryList.ItemsSource = UOW.Products.GetAll();
            RefreshList();
            
        }

        private void RefreshList()
        {
            lbInventoryList.Items.Clear();
            lbInventoryList.ItemsSource = UOW.Products.GetAll();
        }

        private void MainPageAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow();
            addItemWindow.ShowDialog();

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
            removeItemWindow.ShowDialog();

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
            viewAllItemsWindow.ShowDialog();
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
            foreach(StoreItem si in _Store.GetStoreItems())
            {
                si.SetQuantity(0);
            }

            foreach(StoreItem si in fs.GetStoreItems())
            {
                _Store.AddStoreItem(si.Product, si.GetQuantity());
            }
            RefreshList();
        }

        private void buttonGetProductByName_Click(object sender, RoutedEventArgs e)
        {
            List<StoreItem> tempList = new List<StoreItem>();
           tempList = _Store.GetAllProductsByName(textBoxSorting.Text);

            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = tempList;
            viewAllItemsWindow.ShowDialog();
        }

        private void buttonGetProductsByQuantity_Click(object sender, RoutedEventArgs e)
        {
            List<StoreItem> tempList = new List<StoreItem>();
            tempList = _Store.GetProductsByQuantity();

            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = tempList;
            viewAllItemsWindow.ShowDialog();
        }

        private void buttonGetProductsByPrice_Click(object sender, RoutedEventArgs e)
        {
            List<StoreItem> tempList = new List<StoreItem>();
            tempList = _Store.GetProductsByPrice();

            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = tempList;
            viewAllItemsWindow.ShowDialog();
        }
    
    }
}
