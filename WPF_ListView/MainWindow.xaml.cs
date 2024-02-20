using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lsView.Items.Add("A");
            lsView.Items.Add("B");
            lsView.Items.Add("C");
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            lsView.Items.Add(txtBox.Text);
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var tempList = new ArrayList(lsView.SelectedItems);

            if(lsView.SelectedItems.Count>0 && !lsView.Items.IsEmpty)
            {
                foreach (var item in tempList)
                {
                    lsView.Items.Remove(item);
                    
                }
            }

        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {

            if (lsView.Items.Count > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure that you want to delete {lsView.Items.Count} items from the list?","Delete All?",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    lsView.Items.Clear();
                }

            }

        }
    }
}