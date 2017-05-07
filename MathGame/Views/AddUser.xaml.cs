using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MathGame.Commands;
using MathGame.ViewModel;
using Models;

namespace MathGame.Views
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window, INotifyPropertyChanged
    {
        private readonly MathViewModel viewModel;
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


        public AddUser(MathViewModel viewModel) : this()
        {
            this.viewModel = viewModel;
            AddPlayer = new AddPlayerCommand(viewModel);

        }

        public AddUser()
        {
            InitializeComponent();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void showNumberOfQuestions_Click(object sender, RoutedEventArgs e)
        {
            var numberOfQuestions = new NumberOfQuestions(viewModel);
            numberOfQuestions.ShowDialog();
        }
    }
}