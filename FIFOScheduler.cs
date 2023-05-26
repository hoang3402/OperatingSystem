namespace OperatingSystem
{
    internal class FIFOScheduler : Scheduler
    {
        public override Process GetNext()
        {
            return this.processes[0];
        }

        public override void Run()
        {
            Console.WriteLine("Current scheduler is FIFO");
            while (this.processes.Count > 0)
            {
                Process process = GetNext();
                process.RemainingTime--;
                if (process.RemainingTime == 0)
                {
                    this.processes.RemoveAt(0);
                    process.FinishTime = timer + 1;
                    this.turnAroundTime += process.TurnAroundTime;
                    this.waitingTime += process.WaitingTime;
                }
                timer++;
            }
        }
    }
}
