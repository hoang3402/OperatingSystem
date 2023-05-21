using OperatingSystem;

Matrix a = new Matrix(new List<List<int>>()
{
    new List<int>() { 1, 2, 3 },
    new List<int>() { 4, 5, 6 },
    new List<int>() { 7, 8, 9 }
});

Matrix b = new Matrix(new List<List<int>>()
{
    new List<int>() { 1, 2, 3 },
    new List<int>() { 4, 5, 6 },
    new List<int>() { 7, 8, 9 }
});

Matrix c = a * b;

foreach (var item in c.GetMatrix)
{
    foreach (var i in item)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}