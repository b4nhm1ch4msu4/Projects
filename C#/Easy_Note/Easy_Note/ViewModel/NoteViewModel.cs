using Easy_Note.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Easy_Note.ViewModel
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        SQLite_Util SqliteObj = new SQLite_Util();
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Note> _Notes;

        public ObservableCollection<Note> Notes
        {
            get { return SqliteObj.ReadData(); }
            set { }
        }


        private Note _SelectedNote;

        public Note SelectedNote
        {
            get { return _SelectedNote; }
            set { _SelectedNote = value;
                DeleteCommand.RaiseCanExecuteChanged();
                ViewCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Content;

        public string Content
        {
            get { return _Content; }
            set
            {
                _Content = value;
                OnPropertyChanged(nameof(Content));
            }
        }



        public MyCommand DeleteCommand { get; set; }
        public MyCommand NewCommand { get; set; }
        public MyCommand SaveCommand { get; set; }
        public MyCommand ViewCommand { get; set; }

        public NoteViewModel()
        {
            DeleteCommand = new MyCommand(OnDelete, CanDelete);
            NewCommand = new MyCommand(OnNew);
            SaveCommand = new MyCommand(OnSave, CanSave);
            ViewCommand = new MyCommand(OnView, CanView);
        }


        private void OnDelete()
        {
            Notes.Remove(SelectedNote);
            SqliteObj.DeleteData(SelectedNote.Title);
            OnPropertyChanged(nameof(Notes));

        }
        private bool CanDelete()
        {
            return SelectedNote != null;
        }

        private void OnNew()
        {
            Title = string.Empty;
            Content = string.Empty;
        }

        private void OnSave()
        {
            Notes.Add(new Note(Title, Content));
            SqliteObj.AddData(new Note(Title, Content));
            OnPropertyChanged(nameof(Notes));

        }
        private bool CanSave()
        {
            return Title != null;
        }

        private void OnView()
        {
            Title = SelectedNote.Title; Content = SelectedNote.Content;
        }

        private bool CanView()
        {
            return SelectedNote != null;
        }
    }
}
