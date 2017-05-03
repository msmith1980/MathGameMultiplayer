using System;
using System.Windows.Input;

namespace MathGame.Commands
{
    public class CallBackCommand : ICommand
    {
        protected Action Delegate { get; }

        public CallBackCommand(Action delegateToInvoke)
        {
            Delegate = delegateToInvoke;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (Delegate != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Delegate.Invoke();
        }
    }
}
