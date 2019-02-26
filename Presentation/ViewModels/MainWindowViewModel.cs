using GongSolutions.Wpf.DragDrop;
using KnightsWatch.Presentation.Interfaces;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Commands;
using Presentation.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace KnightsWatch.Presentation.ViewModels
{
    public delegate void UpdateCollectionItemDelegate(object obj);

    public class MainWindowViewModel : ObservableObject
    {
        //TODO unit test

        
        private IWindowAdapter windowAdapter;
        private IDataAccessService dataAccessService;
       
        public UserViewModel User { get; set; }
       

        public TabControlViewModel TabControlViewModel {get;set;}
         
        
        
        
        public ICommand CloseWindowCommand { get; set; }
        public ICommand SignOutCommand { get; set; }

        //remove ctor
        public MainWindowViewModel()
        {
            TabControlViewModel = new TabControlViewModel(windowAdapter, new Mediator());
        }

        public MainWindowViewModel( IWindowAdapter adapter,  IDataAccessService dataAccessService)
        {
            
            this.windowAdapter = adapter ?? throw new ArgumentException("Window adapter missing");
            this.dataAccessService = dataAccessService ?? throw new ArgumentException("Data Serverice missing");
            SignOutCommand = new DelegateCommand(SignOut, null);
            CloseWindowCommand = new DelegateCommand(CloseWindow, null);
        }

        private  void CloseWindow()
        {
            windowAdapter.Close();
        }

        //public void DragOver(IDropInfo dropInfo)
        //{
        //    var src = dropInfo.Data as PersonViewModel;
        //    var des = dropInfo.TargetItem as TaskViewModel;

        //    if(src != null && des != null && des.AssignedPeople != null)
        //    {
        //        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
        //        dropInfo.Effects = DragDropEffects.Move;
        //    }


        //}

        //public void Drop(IDropInfo dropInfo)
        //{
        //    DoDragDropTasks(dropInfo);
        //}

        private void SignOut()
        {
            throw new NotImplementedException();
        }

        //private async void DoDragDropTasks(IDropInfo dropInfo)
        //{
        //    var src = dropInfo.Data as PersonViewModel;
        //    var des = dropInfo.TargetItem as TaskViewModel;
        //    if (src.AssingedTask != null)
        //    {
        //        src.AssingedTask.EndTime = DateTime.Now;
        //        dataAccessService.AddTaskItem(src);
        //        await dataAccessService.Commit();
        //    }
        //    if (des.AssignedPeople.Count > 1)
        //    {
        //        var result = await windowAdapter.DialogCoordinator.ShowMessageAsync(this, "Are You Sure", "You already have someone on this assignment, do you want to add another?", MessageDialogStyle.AffirmativeAndNegative);
                 
                
        //        if (result == MessageDialogResult.Negative)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            //Add to observable collection
        //            src.AssingedTask = (new TaskListItemViewModel() { Name = des.Name, StartTime = DateTime.Now });
        //            des.AssignedPeople.Add(src);
        //            //add to db
        //            dataAccessService.AddTaskItem(src);
        //            //commit changes
        //            await dataAccessService.Commit();
        //        }
        //    }
        //}

    }
}
