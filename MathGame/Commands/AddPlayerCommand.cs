using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using MathGame.ViewModel;
using Models;

namespace MathGame.Commands
{
    public sealed class AddPlayerCommand : ICommand, INotifyPropertyChanged
    {
        private readonly MathViewModel viewModel;

        public AddPlayerCommand(MathViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public MathViewModel Viewmodel
        {
            get
            {
                return viewModel;
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
                viewModel.Players.Add(new Player() { Name = tbBox.Text });
                OnPropertyChanged(nameof(Viewmodel));
                tbBox.Text = string.Empty;
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}