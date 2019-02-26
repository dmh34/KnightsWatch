using GongSolutions.Wpf.DragDrop;
using KnightsWatch.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace Presentation.DragDropHandlers
{
    class CallSignDragDropHandler : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            throw new NotImplementedException();
        }

        public void Drop(IDropInfo dropInfo)
        {
            var src = dropInfo.Data as PersonViewModel;
            var des = dropInfo.TargetItem as PersonViewModel;


            if (src != null && des.CallSign == null)
            {
                des.CallSign = src.CallSign;
                ((IList<PersonViewModel>)dropInfo.DragInfo.SourceCollection).Remove(src);
            }



        }

        private bool HasDuplicates(IList<PersonViewModel> destinationCollection, PersonViewModel item)
        {
            return destinationCollection.Contains(item);
        }
    }

    class ActivityDragDropHandeler : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            throw new NotImplementedException();
        }

        public void Drop(IDropInfo dropInfo)
        {
            throw new NotImplementedException();
        }
    }
}
