using System.Collections.Generic;

namespace KnightsWatch.Presentation.ViewModels
{

    //TODO: Need improved state management
    public class PersonViewModel : ObservableObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private CallSignViewModel _callsignViewModel;

        public CallSignViewModel CallSign
        {
            get { return _callsignViewModel; }
            set
            {
                _callsignViewModel = value;
                OnPropertyChanged();
            }
        }

        public TaskListItemViewModel AssingedTask { get; set; }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; } 
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        //public override bool Equals(object obj)
        //{
        //    return tr
        //}

        //public override int GetHashCode()
        //{
        //    return -1125283371 + EqualityComparer<string>.Default.GetHashCode(_name);
        //}
    }
}