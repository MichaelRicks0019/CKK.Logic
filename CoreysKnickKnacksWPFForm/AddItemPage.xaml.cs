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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CKK.Logic.Models;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CoreysKnickKnacksWPFForm
{
   
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            decimal price = decimal.Parse(priceTextBox.Text);
            int quantity = int.Parse(quantityTextBox.Text);
            product.SetName(this.nameTextBox.Text);
            product.SetPrice(price);
            StoreItem item = new StoreItem(product, quantity);
        }
    }
}
