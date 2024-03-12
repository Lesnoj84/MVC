using System.IO;
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

namespace WPF_CS_Tutorials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBoxClass TextBoxClass = new TextBoxClass();

        public MainWindow()
        {
            DataContext = TextBoxClass;
            InitializeComponent();


        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            TextBoxClass.WriteToFile(TextBoxClass.InputedText);

            string FullFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "history.txt");


            List<string> listLines = new List<string>();
            using (StreamReader streamReader = new StreamReader(FullFileName))
            {

                string readlineString = string.Empty;

                while (readlineString != null)
                {
                    readlineString = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(readlineString))
                        listLines.Add(readlineString);
                }
                txtbox.Text = string.Empty;

                myList.ItemsSource = listLines;

            }
           

        }
    }
}