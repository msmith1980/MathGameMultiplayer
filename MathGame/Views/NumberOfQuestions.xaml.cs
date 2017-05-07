using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MathGame.Commands;
using MathGame.ViewModel;

namespace MathGame.Views
{
    /// <summary>
    /// Interaction logic for NumberOfQuestions.xaml
    /// </summary>
    public partial class NumberOfQuestions : Window, INotifyPropertyChanged
    {
        private ICommand _setQuestionsCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SetQuestions
        {
            get
            {
                return _setQuestionsCommand;
            }
            set
            {
                _setQuestionsCommand = value;
                OnPropertyChanged(nameof(SetQuestions));
            }
        }

        public NumberOfQuestions()
        {
            InitializeComponent();
        }

        public NumberOfQuestions(MathViewModel viewModel) : this()
        {
            SetQuestions = new SetNumberOfOperationsCommand(viewModel);

        }

        public MathViewModel MathViewModel { get; internal set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
