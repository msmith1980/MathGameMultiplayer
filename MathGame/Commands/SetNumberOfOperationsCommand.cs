using System;
using System.Windows.Input;
using MathGame.ViewModel;

namespace MathGame.Commands
{
    public sealed class SetNumberOfOperationsCommand : ICommand
    {
        private MathViewModel viewModel;

        public SetNumberOfOperationsCommand(MathViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int outNumberOfQuestions;

            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out outNumberOfQuestions);

                viewModel.NumberOfQuestions = outNumberOfQuestions;
            }
        }

    }
}
