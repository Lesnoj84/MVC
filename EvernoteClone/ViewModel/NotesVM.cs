using EvernoteClone.Model;
using EvernoteClone.View;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helper;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace EvernoteClone.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {

        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook selectedNotebook;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler SelectedNoteChange;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                OnpropertyChanged();
                GetNotes();
            }
        }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value;
                OnpropertyChanged();
                SelectedNoteChange?.Invoke(this, EventArgs.Empty);
            }
        }


        private Visibility isVisible;
        public Visibility IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnpropertyChanged();
            }
        }



        private void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand newNoteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public EndEditingCommand EndEditingCommand { get; set; }
        

        public NotesVM()
        {
            NewNotebookCommand = new(this);
            newNoteCommand = new(this);
            Notebooks = new();
            Notes = new();
            EditCommand = new EditCommand(this);
            EndEditingCommand = new EndEditingCommand(this);

            IsVisible = Visibility.Collapsed;
            

            GetNoteBooks();
        }

        public void CreateNotebook()
        {

            Notebook newNotebok = new()
            {
                Name = "New Notebook"


            };
            DatabaseHelper.Insert(newNotebok);
            GetNoteBooks();
        }


        public void CreateNote(int notebook)
        {
            Note newNote = new Note()
            {
                NotebookId = notebook,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = $"New Note {DateTime.Now.ToShortDateString()}"
            };

            DatabaseHelper.Insert(newNote);
            GetNotes();
        }

        private void GetNoteBooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();
            Notebooks.Clear();
            foreach (Notebook notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
            GetNotes();
        }

        public void GetNotes()
        {
            if (selectedNotebook != null)
            {
                var notes = DatabaseHelper.Read<Note>().Where(n => n.NotebookId == selectedNotebook.Id).ToList();
                Notes.Clear();

                foreach (Note note in notes)
                {
                    Notes.Add(note);

                }
            }
        }

        public void StartEditing()
        {
           
            IsVisible = Visibility.Visible;
            
        }

        public void StopEditing(Notebook notebook)
        {
            isVisible = Visibility.Collapsed;
            DatabaseHelper.Update(notebook);
            GetNoteBooks();

        }
    }

}
