using System;
using System.Collections.Generic;
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
using CKK.Logic.Exceptions;
using CKK.Logic.Models;
using CKK.Logic.Interfaces;
using CKK.DB.UOW;
using CKK.DB.Interfaces;

namespace CoreysKnickKnacksWPFForm
{
    public partial class AddItemWindow : Window
    {

        IConnectionFactory conn = new DatabaseConnectionFactory();
        public UnitOfWork uow;
        public AddItemWindow()
        {
            InitializeComponent();
            uow = new UnitOfWork(conn);

        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

            Product prod = new Product() { Id = int.Parse(idTextBox.Text), Price = decimal.Parse(priceTextBox.Text), Quantity = int.Parse(quantityTextBox.Text), Name = nameTextBox.Text };
            uow.Products.Add(prod);
            DialogResult = true;
            Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    
    }
    
}
