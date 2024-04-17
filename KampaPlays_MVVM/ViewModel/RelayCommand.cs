using KampaPlays_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KampaPlays_MVVM.ViewModel
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {

            _Execute = execute;
            _CanExecute = canExecute;

        }

        public bool CanExecute(object? parameter)
        {
            
            return _CanExecute==null || _CanExecute(parameter);
            
            
        }


        public void Execute(object? parameter)
        {

            _Execute?.Invoke(parameter);
        }
    }
}
