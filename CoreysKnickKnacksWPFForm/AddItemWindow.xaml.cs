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

namespace CoreysKnickKnacksWPFForm
{
    public partial class AddItemWindow : Window
    {

        public StoreItem Item { get; set; }
        public AddItemWindow()
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
            Item = new StoreItem(product, quantity);
            Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
