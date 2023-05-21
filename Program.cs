using OperatingSystem;

List<int> a = new List<int>()
{
    9,8,7,6,5,4,3,2,1
};

OddEvenSort.sort(a);

foreach (int i in a)
{
    Console.Write(i + " ");
}