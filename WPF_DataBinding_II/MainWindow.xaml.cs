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

namespace WPF_DataBinding_II
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Phone> phoneList = new List<Phone>();





        public MainWindow()
        {

            InitializeComponent();

            phoneList.Add(new Phone()
            { Title = "Nexus", Company = "Google", Price = "250" });

            DataContext = phoneList;

        }

        //private void bntClick_Click(object sender, RoutedEventArgs e)
        //{

        //    if (phoneList[0].Company == "Google")
        //    {
        //        phoneList[0].Company = "LG";
        //        phoneList[0].Title = "Arena";
        //        phoneList[0].Price = "180";
        //        myBtn.Background = Brushes.Red;
                



        //    }
        //    else
        //    {
        //        phoneList[0].Company = "Google";
        //        phoneList[0].Title = "Nexus";
        //        phoneList[0].Price = "250";
        //        myBtn.Background = Brushes.Blue;

        //    }
        //}

        private void Button_ClickDP(object sender, RoutedEventArgs e)
        {

            PhoneDependencyObject phone = (PhoneDependencyObject)this.Resources["iPhone6s"];

            

            MessageBox.Show(phone.Price.ToString());

        }
    }
}