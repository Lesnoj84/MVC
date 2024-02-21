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

namespace WPF_CustomControls.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxControl.xaml
    /// </summary>
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl()
        {
            InitializeComponent();
        }
        private string placeholder;

        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                txtBlockPlaceholder.Text = placeholder;

            }
        }


        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = string.Empty;
        }

        private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBlockPlaceholder.Visibility = Visibility.Visible;
            }
            else txtBlockPlaceholder.Visibility = Visibility.Hidden;
        }
    }
}
