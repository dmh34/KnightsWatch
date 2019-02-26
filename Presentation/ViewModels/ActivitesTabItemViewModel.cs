/*
 * Author: D.Hall
 * Created: 8/7/18
*/

using System;
using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using System.Collections;
using Presentation.Interfaces;
using System.Windows;
using System.Collections.Generic;
using KnightsWatch.Presentation.Interfaces;

namespace KnightsWatch.Presentation.ViewModels
{
    public class ActivitesTabItemViewModel : ICompoent
    {
        
        public TaskViewModel Idle { get; set; }
        public ObservableCollection<TaskViewModel> Tasks { get; set; }
        

        private IWindowAdapter windowAdapter;
        private IMediator mediator;

        public ActivitesTabItemViewModel(IWindowAdapter windowAdapter, IMediator mediator)
        {
#if DEBUG
            Idle = new TaskViewModel(mediator) { AssignedPeople = new ObservableCollection<PersonViewModel>(), Name = "Idle" };
            Tasks = new ObservableCollection<TaskViewModel>() { new TaskViewModel(mediator) { Name = "Delta", AssignedPeople = new ObservableCollection<PersonViewModel>() }
            , new TaskViewModel(mediator) { Name = "Alpha", AssignedPeople = new ObservableCollection<PersonViewModel>() } };
#endif
            this.windowAdapter = windowAdapter;
            this.mediator = mediator;
            this.mediator.Register(this); 
        }

        public void RecieveItems(object o)
        {
            if (o is IList<PersonViewModel> objs && objs.Count > 0)
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    if (objs[i].CallSign.Name != "Drop Callsign Here" && !Idle.AssignedPeople.Contains(objs[i]) && !objs[i].IsBusy)
                    {
                        Idle.AssignedPeople.Add(objs[i]);
                    }
                }
            }
        }
    }
}
