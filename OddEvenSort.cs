namespace OperatingSystem
{
    internal class OddEvenSort
    {
        // Việc thực hiện sắp xếp chẵn lẻ bằng lập trình song song sẽ không có ý nghĩa thực tế
        // vì odd-even sort thực chất là việc lặp lại hai lần sắp xếp (lần lẻ và lần chẵn),
        // với bất kỳ lần sắp xếp sau đều sẽ phụ thuộc vào kết quả của lần trước đó.
        // Vẫn có thể thực hiện lập trình song song với thuật toán này
        // bằng cách chia mảng thành các mảng con và sắp xếp các mảng con đó song song,
        // sau đó hợp nhất các mảng con lại với nhau.

        static public void sortThread(List<int> list)
        {
            int n = list.Count - 2;
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;

                Thread _odd = new Thread(() =>
                {
                    int temp = 0;
                    for (int i = 1; i <= n; i += 2)
                    {
                        if (list[i] > list[i + 1])
                        {
                            temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            isSorted = false;
                        }
                    }
                });

                Thread _even = new Thread(() =>
                {
                    int temp = 0;
                    for (int i = 0; i <= n; i += 2)
                    {
                        if (list[i] > list[i + 1])
                        {
                            temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            isSorted = false;
                        }
                    }
                });

                _odd.Start();
                _even.Start();
                _odd.Join();
                _even.Join();
            }
        }

        static public void sort(List<int> list)
        {
            int n = list.Count - 2;
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                int temp = 0;
                for (int i = 1; i <= n; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        isSorted = false;
                    }
                }
                for (int i = 0; i <= n; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        isSorted = false;
                    }
                }
            }
        }
    }
}
