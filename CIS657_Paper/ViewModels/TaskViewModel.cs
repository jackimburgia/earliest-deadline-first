using CIS657_Paper.Entities;
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using static CIS657_Paper.Utilities.UIExtensions;

namespace CIS657_Paper.ViewModels
{


    public class TaskViewModel : ViewModelBase
    {
        internal Task task;

        public Brush Color { get; protected set; }

        public string Name
        {
            get { return this.task.Name; }
            set
            {
                this.task.Name = value;
                this.RaisePropertyChanged(() => Name);
            }
        }


        public int? CycleTime
        {
            get { return this.task.CycleTime; }
            set
            {
                this.task.CycleTime = value.GetValueOrDefault();
                this.RaisePropertyChanged(() => CycleTime);
            }
        }
                

        public int? Deadline
        {
            get { return this.task.Deadline; }
            set
            {
                this.task.Deadline = value.GetValueOrDefault();
                this.RaisePropertyChanged(() => Deadline);
            }
        }        
        

        public int? ProcessingTime
        {
            get { return this.task.ProcessingTime; }
            set
            {
                this.task.ProcessingTime = value.GetValueOrDefault();
                this.RaisePropertyChanged(() => ProcessingTime);
            }
        }

        public TaskViewModel(Task task)
        {
            this.task = task;
            this.Color = GetColor();
        }
    }


}
