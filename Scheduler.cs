namespace OperatingSystem
{
    internal abstract class Scheduler
    {
        protected int timer = 0;
        protected List<Process> processes = new List<Process>();
        protected int turnAroundTime = 0;
        protected int waitingTime = 0;
        protected int numberProcess = 0;

        public int Timer { get => timer; }

        public void AddProcess(Process process)
        {
            this.processes.Add(process);
            this.numberProcess++;
        }

        public void AddProcesses(List<Process> processes)
        {
            this.processes.AddRange(processes);
            this.numberProcess += processes.Count;
        }

        abstract public void Run();

        abstract public Process GetNext();

        public float GetAVGTurnAroundTime()
        {
            Console.WriteLine("TAT = " + this.turnAroundTime);
            return this.turnAroundTime / (float)this.numberProcess;
        }

        public float GetAVGWaitingTime()
        {
            return this.waitingTime / (float)this.numberProcess;
        }
    }
}
