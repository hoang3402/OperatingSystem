// Khởi tạo ma trận max
using OperatingSystem;

int[,] max = new int[,]
{
            {7, 5, 3},
            {3, 2, 2},
            {9, 0, 2},
            {2, 2, 2},
            {4, 3, 3}
};

// Khởi tạo ma trận allocation
int[,] allocation = new int[,]
{
            {0, 1, 0},
            {2, 0, 0},
            {3, 0, 2},
            {2, 1, 1},
            {0, 0, 2}
};

// Khởi tạo mảng available
int[] available = new int[] { 3, 3, 2 };

int process = max.GetLength(0);
int instance = max.GetLength(1);
Banker a = new Banker();
// Kiểm tra trạng thái an toàn
bool isSafe = a.checkSafe(available, max, allocation, process, instance);

Console.WriteLine();
Console.WriteLine("Kiem tra ket qua: " + isSafe);