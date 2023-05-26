namespace OperatingSystem
{
    internal class Process
    {
        string id;
        int arrivalTime;
        int burstTime;
        int turnAroundTime;
        int waitingTime;
        int finishTime;
        int remainingTime;

        public int ArrivalTime { get { return this.arrivalTime; } }
        public int RemainingTime { get { return this.remainingTime; } set { this.remainingTime = value; } }
        public string Id { get { return this.id; } }
        public int FinishTime
        {
            get
            {
                return this.finishTime;
            }
            set
            {
                this.finishTime = value;
                this.turnAroundTime = this.finishTime - this.arrivalTime;
                this.waitingTime = this.turnAroundTime - this.burstTime;
                Console.WriteLine($"Turn Around Time = {this.turnAroundTime} of {this.id}");
                Console.WriteLine($"Waiting Time = {this.waitingTime} of {this.id}");
            }
        }
        public int TurnAroundTime { get { return this.turnAroundTime; } }
        public int WaitingTime { get { return this.waitingTime; } }

        public Process(string id, int arrivalTime, int burstTime)
        {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.burstTime = burstTime;
            this.remainingTime = burstTime;
            this.turnAroundTime = 0;
            this.waitingTime = 0;
        }
    }
}
