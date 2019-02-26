using System.Collections.Generic;
using System.Threading.Tasks;
using KnightsWatch.Presentation.ViewModels;

namespace Presentation.Interfaces
{
    public interface IDataAccessService
    {
        IEnumerable<BulletinBoardItemViewModel> GetBulletinBoardItems();
        IEnumerable<PersonViewModel> GetPersonnel();
        IEnumerable<TaskListItemViewModel> GetCompletedTasks();
        void AddBulletinBoardItem(BulletinBoardItemViewModel item);
        void AddTask(TaskListItemViewModel item);
        List<TaskViewModel> GetTasks();
        void AddTaskItem(PersonViewModel src);
        Task Commit();
    }

    
}