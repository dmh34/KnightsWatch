using GongSolutions.Wpf.DragDrop;
using KnightsWatch.Presentation.Interfaces;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KnightsWatch.Presentation.ViewModels
{
    class TaskListControlViewModel : ICompoent
    {
        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public TaskListControlViewModel()
        {
            Tasks = new ObservableCollection<TaskViewModel>();
        }

        public void RecieveItems(object o)
        {
            var objs = o as IList<PersonViewModel>;

            if (o != null)
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Tasks[i].AssignedPeople.Count == 0) continue;
                    for (int j = 0; j < Tasks[i].AssignedPeople.Count; j++)
                    {
                        if (Tasks[i].AssignedPeople[j].CallSign.Name == "Drop Callsign Here")
                        {
                            Tasks[i].AssignedPeople.Remove(Tasks[i].AssignedPeople[j]);
                        }
                    }
                }
            }

        }


        class PersonnelStatusControlViewModel : ICompoent, IDropTarget
        {

            public ObservableCollection<PersonViewModel> Onduty { get; set; }

            public void DragOver(IDropInfo dropInfo)
            {
                var src = dropInfo.Data as PersonViewModel;
                var des = dropInfo.TargetItem as TaskViewModel;

                if (src != null)
                {
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    dropInfo.Effects = DragDropEffects.Move;
                }
            }

            public void Drop(IDropInfo dropInfo)
            {
                var src = dropInfo.Data as PersonViewModel;
                var des = dropInfo.TargetItem as PersonViewModel;


                if (src == null)
                    return;

                if (src.IsBusy)
                {
                    src.AssingedTask.EndTime = DateTime.Now;
                    src.IsBusy = false;


                    ((IList<PersonViewModel>)dropInfo.DragInfo.SourceCollection).Remove(src);
                }
                AddPersonToTask(src);
            }

            private void AddPersonToTask(PersonViewModel src)
            {
                //src.AssingedTask = new TaskListItemViewModel()
                //{
                //    Name = this.Name,
                //    StartTime = DateTime.Now,
                //    Notes = string.Empty

                //};
                //model.IsBusy = true;
                //if (!Onduty.Contains(model))
                //    Onduty.Add(model);
            }

            public void RecieveItems(object o)
            {
                if (o is IList<PersonViewModel> objs && objs.Count > 0)
                {
                    for (int i = 0; i < objs.Count; i++)
                    {
                        if (objs[i].CallSign.Name != "Drop Callsign Here")
                        {
                            Onduty.Add(objs[i]);
                        }
                    }
                }
            }
        }
    }
}
