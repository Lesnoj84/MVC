using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KampaPlays_MVVM.ViewModel
{
    internal class ShowClass
    {
        
        public ShowClass()
        {

        }

        public void ShowMessage(MainWindow mainWindow)
        {
            

            string text = mainWindow.ItemNameTxtBox.Text;

            MessageBox.Show(text);
        }

    }
}
