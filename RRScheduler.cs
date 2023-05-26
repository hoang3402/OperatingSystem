namespace OperatingSystem
{
    internal class RRScheduler : Scheduler
    {
        int quantum;

        public RRScheduler(int quantum)
        {
            this.quantum = quantum;
        }

        public override Process GetNext()
        {
            return this.processes.First();
        }

        public override void Run()
        {
            Console.WriteLine("Current scheduler is RR");
            while (this.processes.Count > 0)
            {
                Process process = this.GetNext();
                this.processes.Remove(process);
                process.RemainingTime -= this.quantum;
                if (process.RemainingTime <= 0)
                {
                    this.processes.Remove(process);
                    timer += process.RemainingTime == 0 ? this.quantum : Math.Abs(process.RemainingTime);
                    process.FinishTime = timer;
                    this.turnAroundTime += process.TurnAroundTime;
                    this.waitingTime += process.WaitingTime;
                }
                else
                {
                    this.processes.Insert(this.processes.Count, process);
                    timer += this.quantum;
                }
            }
        }
    }
}
