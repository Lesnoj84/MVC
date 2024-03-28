using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
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

namespace WPF_DataBindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        MyData myData = new MyData();

        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = myData;

        }

        private string boundText;
        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        private void setColorBtn_Click(object sender, RoutedEventArgs e)
        {

            

            string colorstr = myData.SetColor;
            
            PropertyInfo[] propertyInfos = typeof(Colors).GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                if (colorstr == info.Name)
                {
                    Color color = (Color)ColorConverter.ConvertFromString(colorstr);
                    bckWindor.Background = new SolidColorBrush(color);
                    return;
                }
            }
            colorstr = string.Empty;

            if (colorstr == string.Empty)
                MessageBox.Show("Color not found"); return;

        }


    }

}
