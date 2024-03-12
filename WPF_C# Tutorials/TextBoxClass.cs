using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CS_Tutorials
{
    internal class TextBoxClass : INotifyPropertyChanged
    {
        private string _inputedText;

        public string InputedText
        {
            get { return _inputedText; }
            set
            {
                _inputedText = value;
                //OnPropertyChange();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;



        private void OnPropertyChange([CallerMemberName] string textpropertyChanged = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(textpropertyChanged));
        }



        public static void WriteToFile(string inputText)
        {


            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string FullFileName = Path.Combine(filePath,"history.txt");

            if (!File.Exists(FullFileName))
            {
                using (var creatFile = File.Create(FullFileName)) ;
            }

            using(StreamWriter sw = new StreamWriter(FullFileName,true))
                 sw.WriteLine(inputText);

        }
    }
}
