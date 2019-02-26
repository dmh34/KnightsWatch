using GongSolutions.Wpf.DragDrop;
using KnightsWatch.Presentation.Interfaces;
using Presentation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace KnightsWatch.Presentation.ViewModels
{
    public class TaskViewModel : ObservableObject, IDropTarget, ICompoent
    {
        private static DispatcherTimer dispatcherTimer;
        public ObservableCollection<PersonViewModel> AssignedPeople { get; set; }
        private IMediator Mediator;
        private IDataAccessService dataAccess;
       
        public string Name { get; internal set; }

        public TaskViewModel(IMediator mediator /*IDataAccessService dataAccess*/)
        {
            this.dataAccess = dataAccess;
            this.Mediator = mediator;
            mediator.Register(this);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += UpdateTime;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            for(int i = 0; i< AssignedPeople.Count; i++)
            {
                if(AssignedPeople[i].AssingedTask != null && AssignedPeople[i].AssingedTask.Name != "Idle")
                {
                    AssignedPeople[i].AssingedTask.ElapsedTime = AssignedPeople[i].AssingedTask.ElapsedTime.Add(new TimeSpan(0, 0, 1));
                }

            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            var src = dropInfo.Data as PersonViewModel;
            var des = dropInfo.TargetItem as TaskViewModel;

            if (src != null && !((IList)dropInfo.TargetCollection).Contains(src))
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        public async void Drop(IDropInfo dropInfo)
        {
            var src = dropInfo.Data as PersonViewModel;
            var des = dropInfo.TargetItem as PersonViewModel;
            

            if (src == null || ((IList)dropInfo.TargetCollection).Contains(src) )
                return;

            if(src.AssingedTask != null) src.AssingedTask.EndTime = DateTime.Now;
                src.IsBusy = false;
                ((IList)dropInfo.DragInfo.SourceCollection).Remove(src);
            
            AddPersonToTask(src);
            //dataAccess.AddTaskItem(src);
            //await dataAccess.Commit();

        }

         private void AddPersonToTask(PersonViewModel model)
         {
            model.AssingedTask = new TaskListItemViewModel()
            {
                Name = this.Name,
                StartTime = DateTime.Now,
                Notes = string.Empty,
                ElapsedTime = new TimeSpan()
            };
            model.IsBusy = true;
            if (!AssignedPeople.Contains(model))
                AssignedPeople.Add(model);
         }

        public void RecieveItems(object o)
        {
            
            if(o != null)
            {
                var objs = (IList<PersonViewModel>)o;
                for (int i = 0; i < objs.Count; i++)
                {
                    if(objs[i].CallSign.Name == "Drop Callsign Here")
                    {
                        //terminate task and remove from list
                        AssignedPeople.Remove(objs[i]);
                        objs[i].IsBusy = false;

                    }                   
                }
            }          
        }    
    }
}