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

namespace CoreysKnickKnacksWPFForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(Store store)
        {
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButtonMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Store tp = (Store)Application.Current.FindResource("globStore");
            Window1 inven = new Window1(tp);
            inven.Show();
            this.Close();
        }
    }
}
