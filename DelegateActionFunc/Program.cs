using System;
using System.Collections.Generic;

namespace DelegateActionFunc
{
    class Program
    {

        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(5, WorkType.Golf);

            Console.ReadLine();
        }


        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Tamamlandi");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Burasi Calisti : {e.Hours} - {e.WorkType}");
        }
    }

    public enum WorkType
    {
        Golf,
        Meeting,
        Reporting
    }
}
