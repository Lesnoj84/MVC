using MVVM_DataBinding.ViewModel;
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

namespace MVVM_DataBinding.View
{
    /// <summary>
    /// Interaction logic for ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        AutoGeneratePeople people = new();

        public ViewWindow()
        {
            InitializeComponent();
            myviewList.ItemsSource = people.GeneratePeople(people.person);

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
