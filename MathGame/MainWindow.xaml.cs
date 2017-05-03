using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MathGame.Commands;
using MathGame.Views;
using Models;

namespace MathGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ICommand AddPlayer
        {
            get
            {
                return new CallBackCommand(() =>
                {
                    var aUser = new AddUser(Players);
                    aUser.ShowDialog();
                });
            }
        }

        ObservableCollection<Player> _players = new ObservableCollection<Player>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Player> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }
    }
}
