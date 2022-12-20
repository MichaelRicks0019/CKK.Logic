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
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;
using CKK.DB.Interfaces;
using CKK.DB.UOW;

namespace CoreysKnickKnacksWPFForm
{
    /// <summary>
    /// Interaction logic for RemoveItem.xaml
    /// </summary>
    public partial class RemoveItem : Window
    {

        IConnectionFactory conn;
        UnitOfWork UOW;
        Product comboBoxProd;
        public RemoveItem()
        {
            InitializeComponent();
            conn = new DatabaseConnectionFactory();
            UOW = new UnitOfWork(conn);
            removeItemComboBox.ItemsSource = UOW.Products.GetAll();
        }

        private void removeItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (removeItemComboBox.SelectedItem != null)
            {
                comboBoxProd = (Product)removeItemComboBox.SelectedItem;
                UOW.Products.Delete(comboBoxProd.Id);
                DialogResult = true;
                Close();
            }

        }

        private void cancelRemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
    }
}
