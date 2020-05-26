using CIS657_Paper.Entities;
using CIS657_Paper.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace CIS657_Paper
{
    /// <summary>
    /// Implementation of the Earliest Deadline First (EDF) scheduling algorithm
    ///     - This is for demonstration purposes
    ///     - When run it returns a collection of data objects describing
    ///         the task and order that they run in
    /// </summary>
    public class EarliestDeadlineFirstScheduler
    {
        public IEnumerable<ScheduleTime> Run(IEnumerable<Task> tasks, int lcm)
        {
            int time = 0;

            // iterate through each point int time
            while (time < lcm)
            {
                // Determine the next task that has to be run
                Task next = tasks
                    .Where(t => t.NextStart() <= time) // cannot run until the current time is the next start 
                    .OrderBy(t => t.NextDeadline()) // sort by the closest deadline
                    .FirstOrDefault();

                if (next == null)
                {
                    // no eligible processes to be run
                    time++;
                }
                else
                {
                    // iterate through the cycle time and return a record of the process running at this time
                    for (int x = 0; x < next.CycleTime; x++)
                        yield return new ScheduleTime() { Time = time + x, Task = next };

                    time += next.CycleTime; // increment the current position by the cycle time 
                    next.State++; // increment the state- this tracks how many times the proess has run
                }
            }
        }
    }
}
