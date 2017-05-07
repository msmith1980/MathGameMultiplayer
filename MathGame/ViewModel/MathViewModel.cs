using System.Collections.ObjectModel;
using System.ComponentModel;
using Models;

namespace MathGame.ViewModel
{
    public sealed class MathViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Player> players;
        private int numberOfQuestions;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Player> Players
        {
            get
            {
                return players;
            }
            set
            {
                players = value;
            }
        }

        public int NumberOfQuestions
        {
            get
            {
                return numberOfQuestions;
            }
            set
            {
                numberOfQuestions = value;
                OnPropertyChanged(nameof(NumberOfQuestions));
            }
        }

        public MathViewModel()
        {
            Players = new ObservableCollection<Player>();
        }

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}