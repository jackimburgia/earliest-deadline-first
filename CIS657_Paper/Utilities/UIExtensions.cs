using CIS657_Paper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;



namespace CIS657_Paper.Utilities
{
    public static class UIExtensions
    {
        private static readonly Random rnd = new Random();
        private static readonly object syncLock = new object();
        
        /// <summary>
        /// Randomly generate a color
        /// </summary>
        /// <returns></returns>
        public static SolidColorBrush GetColor()
        {
            lock (syncLock)
            {
                Color color = Color.FromRgb(Convert.ToByte(rnd.Next(0,255)), Convert.ToByte(rnd.Next(0, 255)), Convert.ToByte(rnd.Next(0, 255)));
                return new SolidColorBrush(color);
            }

        }

        /// <summary>
        /// Add "blank" records to the shedule when no processes ran
        /// </summary>
        /// <param name="timeLine"></param>
        /// <returns></returns>
        public static IEnumerable<ScheduleTime> AddMissing(this List<ScheduleTime> timeLine)
        {
            for(int x = 1; x < timeLine.Count; x++)
            {
                int diff = timeLine[x].Time - timeLine[x-1].Time;
                if (diff > 1)
                {
                    for (int i = 1; i < diff; i++)
                        yield return new ScheduleTime() { Time = timeLine[x - 1].Time + i };
                }

            }
        }

        static int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        public static int LCM(int a, int b)
        {
            return (a * b) / gcd(a, b);
        }

        public static int LeastCommonMultiple(this IEnumerable<int> values)
        {
            var arr = values.ToArray();

            if (arr.Length == 0)
                return 0;

            int lcm = arr.First();
            foreach (var val in arr.Skip(1))
                lcm = LCM(lcm, val);

            return lcm;
        }

    }
}


