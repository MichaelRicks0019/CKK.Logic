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

namespace CoreysKnickKnacksWPFForm
{
    /// <summary>
    /// Interaction logic for RemoveItem.xaml
    /// </summary>
    public partial class RemoveItem : Window
    {
        public ComboBox removeItemComboBoxPH { get; set; }
        public RemoveItem()
        {
            InitializeComponent();
        }

        public ComboBox CombineComboBox()
        {
            removeItemComboBoxPH = removeItemComboBox;
            return removeItemComboBoxPH;
        }
    }
}
