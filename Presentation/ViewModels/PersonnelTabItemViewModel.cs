/*
 * Author: D.Hall
 * Created: 8/7/18
*/


namespace KnightsWatch.Presentation.ViewModels
{
    public class PersonnelTabItemViewModel:ObservableObject
    {
        private PersonnelControlViewModel _personnelControlViewModel;
        public PersonnelControlViewModel PersonnelControlViewModel
        {
            get { return _personnelControlViewModel; } 
            set
            {
                _personnelControlViewModel = value;
                OnPropertyChanged();
            }
        }


        public PersonnelTabItemViewModel(Interfaces.IMediator mediator)
        {
            PersonnelControlViewModel = new PersonnelControlViewModel(mediator);
        }
    }
}
