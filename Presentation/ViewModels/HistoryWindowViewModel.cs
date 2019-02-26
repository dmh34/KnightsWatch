using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsWatch.Presentation.ViewModels
{
    public class HistoryWindowViewModel : ObservableObject
    {
        public PersonViewModel Person { get; set; }
        public ObservableCollection<TaskListItemViewModel> TaskHistory { get; set; }
    }
}
