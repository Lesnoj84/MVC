using KampaPlays_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KampaPlays_MVVM.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; }
        int increment = 0;

        public ShowClass ShowClass { get; set; }
        MainWindow MainWindow { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand RemoveCommand => new RelayCommand(execute => RemoveItem(), canExecute => SelectedItem != null);

        public RelayCommand CloseCommand => new RelayCommand(execute => Close());

        public RelayCommand ShowCommand => new RelayCommand(execute => ShowClass.ShowMessage(MainWindow));
        public MainWindowViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            Items = new ObservableCollection<Item>();
            ShowClass = new ShowClass();

        }

        private Item selectedItem;


        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void AddItem()
        {
            Items.Add(new Item()
            {
                ItemName = $"Product{increment}",
                SerialNumber = $"XX{increment}-XXX-{DateTime.Now.ToShortDateString()}",
                Quantity = new Random().Next(1, 100)
            });

            increment++;
        }

        private void RemoveItem()
        {
            Items.Remove(SelectedItem);
        }

        private void Close()
        {
            Application.Current.Shutdown();
        }


    }
}
