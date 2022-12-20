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
        public Window1(IConnectionFactory conn)
        {
            InitializeComponent();
            UOW = new UnitOfWork(conn);
            RefreshList();
            
        }

        private void RefreshList()
        {
            List<Product> list = new List<Product>();
            List<Product> list2 = new List<Product>();
            list = UOW.Products.GetAll();
            foreach (Product prod in list)
            {
                Product prod2 = new Product();
                prod2.Name = prod.Name;
                prod2.Id = prod.Id;
                prod2.Price = prod.Price;
                prod2.Quantity= prod.Quantity;
                list2.Add(prod2);
            }
            lbInventoryList.ItemsSource = list2;
        }

        private void MainPageAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow();
            addItemWindow.ShowDialog();

            if (addItemWindow.DialogResult == true)
            {
                Product prod = new Product() { Id = int.Parse(addItemWindow.idTextBox.Text), Price = decimal.Parse(addItemWindow.priceTextBox.Text), Quantity = int.Parse(addItemWindow.quantityTextBox.Text), Name = addItemWindow.nameTextBox.Text };
                UOW.Products.Add(prod);
                RefreshList();
            }

        }

        private void RemoveAllItems_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem removeItemWindow = new RemoveItem();
            removeItemWindow.removeItemComboBox.ItemsSource = UOW.Products.GetAll();
            removeItemWindow.ShowDialog();

            if(removeItemWindow.DialogResult == true)
            {
                RefreshList();
            }
    
        }

        private void ViewAllItems_Click(object sender, RoutedEventArgs e)
        {
            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = UOW.Products.GetAll();
            viewAllItemsWindow.ShowDialog();
        }

        private void LoadItems_CLick(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void buttonGetProductByName_Click(object sender, RoutedEventArgs e)
        {
            List<Product> tempList = new List<Product>();
            tempList = UOW.Products.GetByName(textBoxSorting.Text);

            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = tempList;
            viewAllItemsWindow.ShowDialog();
        }

        private void buttonGetProductsByQuantity_Click(object sender, RoutedEventArgs e)
        {
            List<Product> tempList = new List<Product>();
            List<Product> tempListQuantity = new List<Product>();
            tempList = UOW.Products.GetAll();
            foreach (Product prod in tempList)
            {
                if(prod.Quantity == int.Parse(textBoxSorting.Text))
                {
                    tempListQuantity.Add(prod);
                }
            }

            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = tempListQuantity;
            viewAllItemsWindow.ShowDialog();
        }

        private void buttonGetProductsByPrice_Click(object sender, RoutedEventArgs e)
        {
            List<Product> tempList = new List<Product>();
            List<Product> tempListPrice = new List<Product>();
            tempList = UOW.Products.GetAll();
            foreach (Product prod in tempList)
            {
                if (prod.Price == decimal.Parse(textBoxSorting.Text))
                {
                    tempListPrice.Add(prod);
                }
            }

            ViewAllItemsWindow viewAllItemsWindow = new ViewAllItemsWindow();
            viewAllItemsWindow.viewAllItemsListBox.ItemsSource = tempListPrice;
            viewAllItemsWindow.ShowDialog();
        }
    
    }
}
