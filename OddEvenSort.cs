namespace OperatingSystem
{
    internal class OddEvenSort
    {
        static public void sort(List<int> list)
        {
            int n = list.Count;
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                int temp = 0;
                for (int i = 1; i <= n - 2; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        isSorted = false;
                    }
                }
                for (int i = 0; i <= n - 2; i += 2)
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
