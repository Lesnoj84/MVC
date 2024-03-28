using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class EndEditingCommand : ICommand
    {
        public NotesVM ViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public EndEditingCommand(NotesVM notesVM)
        {
            ViewModel = notesVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Notebook notebook = parameter as Notebook;
            if (notebook != null)
            {
                ViewModel.StopEditing(notebook);
            }
        }
    }
}
