using CIS657_Paper.Entities;
using GalaSoft.MvvmLight;

namespace CIS657_Paper.ViewModels
{
    public class ScheduleTimeViewModel : ViewModelBase
    {
        internal ScheduleTime time;
        public int Time { get { return this.time.Time; } }
        public TaskViewModel Task { get; }

        public ScheduleTimeViewModel(ScheduleTime timeline, TaskViewModel task)
        {
            this.time = timeline;
            this.Task = task;
        }
    }


}
