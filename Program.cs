
using OperatingSystem;

List<Process> processes = new List<Process>()
{
    new Process("P1", 0, 7),
    new Process("P2", 1, 5),
    new Process("P3", 2, 4),
    new Process("P4", 3, 7),
    new Process("P5", 4, 1),
};

//var FIFO = new FIFOScheduler();

//FIFO.AddProcesses(processes);

//FIFO.Run();

//var temp = FIFO.GetAVGTurnAroundTime();
//Console.WriteLine($"Average Turn Around Time: {temp}");
//temp = FIFO.GetAVGWaitingTime();
//Console.WriteLine($"Average Waiting Time: {temp}");


//Console.WriteLine("=====================================");

//var SJF = new SJFScheduler();

//SJF.AddProcesses(processes);

//SJF.Run();

//var temp = SJF.GetAVGTurnAroundTime();
//Console.WriteLine($"Average Turn Around Time: {temp}");
//temp = SJF.GetAVGWaitingTime();
//Console.WriteLine($"Average Waiting Time: {temp}");

Console.WriteLine("=====================================");

var RR = new RRScheduler(2);

RR.AddProcesses(processes);

RR.Run();

var temp = RR.GetAVGTurnAroundTime();
Console.WriteLine($"Average Turn Around Time: {temp}");
temp = RR.GetAVGWaitingTime();
Console.WriteLine($"Average Waiting Time: {temp}");