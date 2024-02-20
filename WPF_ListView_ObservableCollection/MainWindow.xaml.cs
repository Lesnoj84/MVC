using System.Collections;
using System.Collections.ObjectModel;
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

namespace WPF_ListView_ObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string>entries = new ObservableCollection<string>();

        public ObservableCollection<string> Entries
        {
            get { return entries; }
            set { entries = value; } 
        }


        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            entries.Add(txtBox.Text);
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var removeItems = new ArrayList(lsView.SelectedItems);

            foreach (var item in removeItems)
            {
                entries.Remove((string)item);
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            entries.Clear();
        }
    }
}