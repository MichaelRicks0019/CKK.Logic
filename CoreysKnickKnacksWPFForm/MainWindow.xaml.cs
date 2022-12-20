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
using CKK.Logic;
using System.Collections.ObjectModel;
using CKK.Persistance.Interfaces;
using CKK.Persistance.Models;
using CKK.DB.UOW;
using CKK.DB.Interfaces;
using System.Data;
namespace CoreysKnickKnacksWPFForm
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

        }

        private void loginButtonMainWindow_Click(object sender, RoutedEventArgs e)
        {
            IConnectionFactory conn = new DatabaseConnectionFactory();
            Window1 inven = new Window1(conn);
            inven.Show();
            this.Close();
           
        }
    }
    
}
