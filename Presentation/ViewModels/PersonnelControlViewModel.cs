/*
 * Author: D.Hall
 * Created: 8/7/18
 * TOOD: Have class 2) Make entry everytime callsign is changed
*/

using System;
using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using Presentation.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Collections;
using KnightsWatch.Presentation.Interfaces;

namespace KnightsWatch.Presentation.ViewModels
{
    public class PersonnelControlViewModel : ObservableObject,IDropTarget
    {
       
        public UpdateCollectionItemDelegate UpdateItemHandler { get { return (obj) => OnItemUpdate(obj); } }

        private IMediator mediator;
        public ObservableCollection<PersonViewModel> Roster { get; set; }
        public ObservableCollection<PersonViewModel> CallSigns { get; set; }

        public PersonnelControlViewModel(IMediator mediator)
        {
#if DEBUG
            Roster = new ObservableCollection<PersonViewModel>()
            { new PersonViewModel() { Name = "Jim Bob", IsBusy = false, CallSign = new CallSignViewModel() { Name = "Drop Callsign Here", CallSignAssigned = true } }, new PersonViewModel() { Name = "Tim", CallSign = new CallSignViewModel() { Name = "Drop Callsign Here", CallSignAssigned = true } } };
            CallSigns = new ObservableCollection<PersonViewModel>()
            { new PersonViewModel() { CallSign = new CallSignViewModel() { Name = "Lead" } }, new PersonViewModel() { CallSign = new CallSignViewModel() { Name = "CCO" } } };
#endif
            this.mediator = mediator;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            var src = dropInfo.Data as PersonViewModel;
            var des = dropInfo.TargetItem as PersonViewModel;

            if (src != null && des != null )
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            var src = dropInfo.Data as PersonViewModel;
            var des = dropInfo.TargetItem as PersonViewModel;
            
            
           
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Insert position {0}, TargetItem {1}", dropInfo.InsertPosition, dropInfo.TargetItem);
#endif
            var temp = src.CallSign;
            src.CallSign = des.CallSign;
            des.CallSign = temp;        
        }

        private void OnItemUpdate(object obj)
        {
            mediator.SendObjects(Roster);
        }
    }
}
