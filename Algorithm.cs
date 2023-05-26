namespace OperatingSystem
{
    internal class Algorithm
    {
        string name;
        string shortName;
        bool preemtive;

        public Algorithm(string name, string shortName, bool preemtive = false)
        {
            this.name = name;
            this.shortName = shortName;
            this.preemtive = preemtive;
        }

        static public Algorithm FIFO = new Algorithm("First in First out", "FIFO");
        static public Algorithm RR = new Algorithm("Round Robin", "RR");
        static public Algorithm SJFnonpreemtive = new Algorithm("Shortest-Job-First nonpreemtive", "RR");
    }
}
