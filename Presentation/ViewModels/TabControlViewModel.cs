/*
 * Author: D.Hall
 * Created: 8/7/18
*/

using KnightsWatch.Presentation.Interfaces;
using Presentation.Interfaces;
using System.Collections.Generic;

namespace KnightsWatch.Presentation.ViewModels
{
    public class TabControlViewModel: ObservableObject
    {
        private PersonnelTabItemViewModel _personnelTabItemViewModel;
        private ActivitesTabItemViewModel _activitiesTabItemViewModel;
        private BulletinBoardTabItemViewModel _bulletinBoardTabItemViewModel;

       

        public TabControlViewModel(IWindowAdapter windowAdapter, IMediator mediator)
        {
            PersonnelTabItemViewModel = new PersonnelTabItemViewModel(mediator);
            ActivitesTabItemViewModel = new ActivitesTabItemViewModel(windowAdapter, mediator);
            BulletinBoardTabItemViewModel = new BulletinBoardTabItemViewModel();
        }

        public PersonnelTabItemViewModel PersonnelTabItemViewModel
        {
            get
            {
                return _personnelTabItemViewModel;
            }
            set
            {
                _personnelTabItemViewModel = value;
                OnPropertyChanged();
            }
        }


        public ActivitesTabItemViewModel ActivitesTabItemViewModel
        {
            get
            {
                return _activitiesTabItemViewModel;
            }
            set
            {
                _activitiesTabItemViewModel = value;
                OnPropertyChanged();
            }
        }
        public BulletinBoardTabItemViewModel BulletinBoardTabItemViewModel
        {
            get
            {
                return _bulletinBoardTabItemViewModel;
            }
            set
            {
                _bulletinBoardTabItemViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
