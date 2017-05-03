using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MathGame.Commands;
using Models;

namespace MathGame.Views
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Player> _playerList;
        private ICommand _addPlayerCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddPlayer
        {
            get
            {
                return _addPlayerCommand;
            }
            set
            {
                _addPlayerCommand = value;
                OnPropertyChanged(nameof(AddPlayer));
            }
        }

        public AddUser(ObservableCollection<Player> players) : this()
        {
            Players = players;
            AddPlayer = new AddPlayerCommand(Players);
        }

        public AddUser()
        {
            InitializeComponent();
        }

        public ObservableCollection<Player> Players
        {
            get
            {
                return _playerList;
            }
            set
            {
                _playerList = value;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}