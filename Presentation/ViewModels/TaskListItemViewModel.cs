using System;

namespace KnightsWatch.Presentation.ViewModels
{
    public class TaskListItemViewModel : ObservableObject
    {
        private string _name;
        private DateTime _startTime;
        private TimeSpan _elaspsedTime;
        private DateTime? _endTime;
        private string _notes;

        public TimeSpan ElapsedTime
        {
            get { return _elaspsedTime; }
            set
            {
                _elaspsedTime = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged();
            }
        }
        public DateTime? EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged();
            }
        }
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
    }
}