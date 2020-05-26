using CIS657_Paper.Entities;

namespace CIS657_Paper.Utilities
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Returns the next deadline for a task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static int NextDeadline(this Task task)
        {
            int next = task.Deadline + task.State * task.ProcessingTime;
            return next;
        }

        /// <summary>
        /// Returns the next point in time that a task can start
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static int NextStart(this Task task)
        {
            int next = task.ProcessingTime * task.State;
            return next;
        }
    }
}


