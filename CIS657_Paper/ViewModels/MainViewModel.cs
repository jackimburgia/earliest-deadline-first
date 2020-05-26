using CIS657_Paper.Entities;
using CIS657_Paper.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CIS657_Paper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<TaskViewModel> Tasks { get; set; } = new ObservableCollection<TaskViewModel>();
        public ObservableCollection<ScheduleTimeViewModel> Schedule { get; set; } = new ObservableCollection<ScheduleTimeViewModel>();

        private TaskViewModel newTask;
        public TaskViewModel NewTask { 
            get { return this.newTask; }
            set
            {
                this.newTask = value;
                this.RaisePropertyChanged(() => NewTask);
            }
        }


        private int? lcm;
        public int? LCM
        {
            get { return this.lcm; }
            set
            {
                this.lcm = value;
                this.RaisePropertyChanged(() => LCM);
            }
        }

        #endregion



        #region Commands

        private ICommand addTaskCommand;
        public ICommand AddTaskCommand
        {
            get { return this.addTaskCommand ?? (this.addTaskCommand = new RelayCommand(
                AddTask, 
                () => this.NewTask.CycleTime.GetValueOrDefault() > 0
                    && this.NewTask.Deadline.GetValueOrDefault() > 0
                    && this.NewTask.ProcessingTime.GetValueOrDefault() > 0
            )); }
        }        
        
        private ICommand runCommand;
        public ICommand RunCommand
        {
            get { return this.runCommand ?? (this.runCommand = new RelayCommand(
                Run, 
                () => this.lcm.GetValueOrDefault() > 0
                    && this.Tasks.Count > 0
            )); }
        }


        #endregion




        public MainViewModel()
        {
            this.NewTask = new TaskViewModel(new Task());
        }

        #region Methods


        private void Run()
        {
            this.Schedule.Clear();
            foreach(var task in this.Tasks)
            {
                task.task.State = 0; ;
            }

            var tasks = this.Tasks.Select(t => t.task).ToArray();

            var scheduler = new EarliestDeadlineFirstScheduler();

            var schedule = scheduler.Run(tasks, this.LCM.Value).ToList();

            var missing = schedule.AddMissing().ToArray();
            schedule.AddRange(missing);


            foreach(var t in schedule.OrderBy(tl => tl.Time))
            {
                this.Schedule.Add(new ScheduleTimeViewModel(t, this.Tasks.SingleOrDefault(tt => tt.task == t.Task)));
            }

        }

        private void AddTask() {
            this.NewTask.Name = $"Task {this.Tasks.Count}";
            this.Tasks.Add(this.NewTask);

            this.NewTask = new TaskViewModel(new Task());
            this.LCM = this.Tasks.Select(t => t.ProcessingTime.GetValueOrDefault()).LeastCommonMultiple();
        }


        #endregion

    }
}
