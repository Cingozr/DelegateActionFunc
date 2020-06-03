using System;
using System.Threading;

namespace DelegateActionFunc
{ 
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public virtual void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }

            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            if (WorkPerformed is EventHandler<WorkPerformedEventArgs> del)
                del(this, new WorkPerformedEventArgs(hours, workType));

        }

        protected virtual void OnWorkCompleted()
        {
            if (WorkCompleted is EventHandler eventHandler)
                eventHandler(this, EventArgs.Empty);
        }


    }
}
