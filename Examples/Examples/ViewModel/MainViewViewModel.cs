using Examples.Commands;
using Examples.Model;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Examples.ViewModel
{
    class MainViewViewModel : ViewModelBase
    {
        private ICollectionView _friendView;
        public FriendCollection Friends { get; private set; }
        public ICommand NextCommand { get; private set; }
        public ICommand PreviousCommand { get; private set; }

        public MainViewViewModel()
        {
            LoadData();
            _friendView = CollectionViewSource.GetDefaultView(Friends);
            _friendView.MoveCurrentToFirst();
            NextCommand = new ActionCommand(OnNextExecuted, OnNextCanExecute);
            PreviousCommand = new ActionCommand(OnPreviousExecute, OnPreviousCanExecute);
        }

        public void OnNextExecuted(object parameter)
        {
            _friendView.MoveCurrentToNext();
        }

        public bool OnNextCanExecute(object parameter)
        {
            return _friendView.CurrentPosition < Friends.Count - 1;
        }

        public void OnPreviousExecute(object parameter)
        {
            _friendView.MoveCurrentToPrevious();
        }

        public bool OnPreviousCanExecute(object parameter)
        {
            return _friendView.CurrentPosition > 0;
        }
        private void LoadData()
        {
            Friends = new FriendCollection();
            Friends.Add(new Friend { FirstName = "Tim", LastName = "Brown" });
            Friends.Add(new Friend { FirstName = "Sarah", LastName = "White" });
            Friends.Add(new Friend { FirstName = "Peter", LastName = "Green" });
        }
    }
}
