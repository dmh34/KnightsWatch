using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Presentation.Interfaces;

using Domain;
using KnightsWatch.Entites;
using KnightsWatch.Presentation.ViewModels;

namespace Service
{
    public class DataAccessService : IDataAccessService
    {
        private IMapper mapper;
        private IRepository<Person> personRepo;
        private IRepository<PersonnelTask> taskrepo;
        private IRepository<PassDown> passdownrepo;

        public DataAccessService(IMapper mapper, IRepository<Person> personrepo, IRepository<PersonnelTask> taskrepo, IRepository<PassDown> passdownrepo)
        {
            this.mapper = mapper;
            this.personRepo = personrepo;
            this.taskrepo = taskrepo;
            this.passdownrepo = passdownrepo;
        }

        public void AddBulletinBoardItem(BulletinBoardItemViewModel item)
        {
            
                var mappeditem = mapper.Map<BulletinBoardItemViewModel, PassDown>(item);
                passdownrepo.Add(mappeditem);
        }

        public void AddTask(TaskListItemViewModel item)
        {
            throw new NotImplementedException();
        }

        public void AddTaskItem(PersonViewModel src)
        {
            throw new NotImplementedException();
        }

        public Task Commit()
        {
            throw new NotImplementedException();
        }

        //public void AddBulletinBoardItem(BulletinBoardItemViewModel item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddTask(TaskListItemViewModel item)
        //{
        //    if (item != null)
        //        taskrepo.Add(mapper.Map<TaskListItemViewModel, PersonnelTask>(item));
        //}

        //public void AddTask(TaskListItemViewModel item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddTaskItem(PersonViewModel src)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddTaskItem(PersonViewModel src)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task Commit()
        //{

        //}

        public IEnumerable<BulletinBoardItemViewModel> GetBulletinBoardItems()
        {
            var mappedItem = mapper.Map<IEnumerable<PassDown>, IEnumerable<BulletinBoardItemViewModel>>(passdownrepo.GetAllEntities());
            return mappedItem;
        }

        public IEnumerable<TaskListItemViewModel> GetCompletedTasks() 
        {
            var mappedItem = mapper.Map<IEnumerable<PersonnelTask>, IEnumerable<TaskListItemViewModel>>(taskrepo.GetAllEntities());
            return mappedItem;
        }

        public IEnumerable<PersonViewModel> GetPersonnel()
        {
            var mappedItem = mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(personRepo.GetAllEntities());
            return mappedItem;
        }

        public List<TaskViewModel> GetTasks()
        {
            throw new NotImplementedException();
        }

        IEnumerable<BulletinBoardItemViewModel> IDataAccessService.GetBulletinBoardItems()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TaskListItemViewModel> IDataAccessService.GetCompletedTasks()
        {
            throw new NotImplementedException();
        }

        IEnumerable<PersonViewModel> IDataAccessService.GetPersonnel()
        {
            throw new NotImplementedException();
        }

        List<TaskViewModel> IDataAccessService.GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}
