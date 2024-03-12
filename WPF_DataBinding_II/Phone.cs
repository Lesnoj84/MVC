using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_DataBinding_II
{

    internal class Phone : INotifyPropertyChanged
    {
        private string title;
        private string company;
        private string price;

        public string Title { get => title; set { title = value; OnpropertyChanged(); } }
        public string Company { get => company; set { company = value; OnpropertyChanged(); } }
        public string Price { get => price; set { price = value; OnpropertyChanged(); } }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnpropertyChanged([CallerMemberName] string phone = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(phone));
        }


    }
}
