using System;

namespace KnightsWatch.Presentation.ViewModels
{
    public class BulletinBoardItemViewModel : ObservableObject
    {
        private bool _isCritical;
        private string _creator;
        private string _entry;
        private DateTime _creationDateTime;
        private DateTime? _endDateTime;
        private bool _canEdit;

        public bool IsCritical
        {
            get { return _isCritical; }
            set
            {
                _isCritical = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get { return _creator; }
            set
            {
                _creator = value;
                OnPropertyChanged();
            
            }
        }

        public string Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }
       
        public DateTime CreationTime
        {
            get { return _creationDateTime; }
            set
            {
                _creationDateTime = value;
                OnPropertyChanged();

            }
        }
        
        public DateTime? EndDate
        {
            get { return _endDateTime; }
            set
            {
                _endDateTime = value;
                OnPropertyChanged();
            }
        }

        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                _canEdit = value;
                OnPropertyChanged();
            }
        }
        public DateTime? ExpirationDate
        {
            get { return _endDateTime; }
            set
            {
                _endDateTime = value;
                OnPropertyChanged();
            }
        }
        public bool CanBeEdited { get; set; }
    }
}