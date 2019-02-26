using Presentation.Commands;
using Presentation.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KnightsWatch.Presentation.ViewModels
{
    public class BulletinBoardViewModel
    {
        private IDataAccessService dataAccessService;

        public ICommand SubmitCommand { get; private set; }
        public BulletinBoardItemViewModel SelectedItem { get; set; }

        public BulletinBoardViewModel(IDataAccessService dataAccess)
        {
            //this.dataAccessService = dataAccess ?? throw new ArgumentException("Data Service missing");
            //BulletinBoardItems = new ObservableCollection<BulletinBoardItemViewModel>(dataAccess.GetBulletinBoardItems());
            //SubmitCommand = new DelegateCommand(Submit, null);

            //Remove Later
            BulletinBoardItems = new ObservableCollection<BulletinBoardItemViewModel>()
                { new BulletinBoardItemViewModel(){ CanBeEdited = false, Creator = "Jim Bob", Entry ="Check Elevator Hourly", IsCritical = true, CreationTime = DateTime.Now }
            };
        }

        
        private void Submit()
        {
            dataAccessService.Commit();
        }

        public ObservableCollection<BulletinBoardItemViewModel> BulletinBoardItems { get; set; }
    }
}