using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MathGame.Commands;
using MathGame.ViewModel;
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
                    var aUser = new AddUser(MathViewModel);
                    aUser.ShowDialog();
                });
            }
        }

        MathViewModel _viewModel = new MathViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public MathViewModel MathViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                OnPropertyChanged(nameof(MathViewModel));
            }
        }

        public int NumberOfQuestions { get; set; }

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
