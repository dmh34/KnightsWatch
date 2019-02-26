/*
 * Author: D.Hall
 * Created: 8/7/18
*/

namespace KnightsWatch.Presentation.ViewModels
{
    public class CallSignViewModel : ObservableObject
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
        public bool CallSignAssigned { get; set; }
    }
}