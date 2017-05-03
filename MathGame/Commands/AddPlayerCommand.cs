using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Models;

namespace MathGame.Commands
{
    public sealed class AddPlayerCommand : ICommand, INotifyPropertyChanged
    {
        private ObservableCollection<Player> _playerList;

        public AddPlayerCommand(ObservableCollection<Player> player)
        {
            Player = player;
        }

        public ObservableCollection<Player> Player
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

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var tbBox = parameter as TextBox;
            if (tbBox != null)
            {
                Player.Add(new Player() { Name = tbBox.Text });
                OnPropertyChanged(nameof(Player));
                tbBox.Text = string.Empty;
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}