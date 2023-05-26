namespace OperatingSystem
{
    internal class SJFScheduler : Scheduler
    {
        public override Process GetNext()
        {
            Process process = this.processes[0];
            foreach (var item in this.processes)
            {
                if (item.RemainingTime < process.RemainingTime && timer >= item.ArrivalTime)
                {
                    process = item;
                }
            }
            return process;
        }
        public override void Run()
        {
            Console.WriteLine("Current scheduler is SJF(Preemptive)");
            while (this.processes.Count > 0)
            {
                Process process = GetNext();
                Console.WriteLine($"Current time is {timer} - {process.Id} running");
                process.RemainingTime--;
                if (process.RemainingTime == 0)
                {
                    this.processes.Remove(process);
                    process.FinishTime = timer + 1;
                    this.turnAroundTime += process.TurnAroundTime;
                    this.waitingTime += process.WaitingTime;
                }
                timer++;
            }
        }
    }
}
