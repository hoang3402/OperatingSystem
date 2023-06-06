namespace OperatingSystem
{
    internal class Banker
    {
        public void nhapMT(int n, int m, int[,] x)
        {

            for (int i = 0; i < n; i++)
            {
                Console.Write("P{0}: ", i);
                var array = Console.ReadLine();
                var arrays = array?.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    x[i, j] = Convert.ToInt32(arrays?[j]);
                }
            }
        }

        public void nhapAvailable(int n, int[] x)
        {
            var array = Console.ReadLine();
            var arrays = array?.Split(' ');

            for (int i = 0; i < n; i++)
            {


                x[i] = Convert.ToInt32(arrays?[i]);

            }
        }

        public void mtNeed(int[,] a, int[,] b, int[,] kq, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    kq[i, j] = a[i, j] - b[i, j];
                }
            }
        }

        public bool checkSafe(int[] available, int[,] max, int[,] allocation, int process, int instance)
        {
            //khởi tạo finish 
            int[,] need = new int[process, instance];
            bool[] finish = new bool[process];

            //tinh mang need
            for (int i = 0; i < process; i++)
            {
                for (int j = 0; j < instance; j++)
                {
                    need[i, j] = max[i, j] - allocation[i, j];
                }
            }
            //khởi tạo work va safe
            int[] work = new int[instance];
            int[] safeSequence = new int[process];
            Array.Copy(available, work, instance);

            int count = 0;

            while (count < process)
            {
                bool found = false;

                for (int i = 0; i < process; i++)
                {
                    if (!finish[i])
                    {
                        bool canExecute = true;
                        for (int j = 0; j < instance; j++)
                        {
                            if (need[i, j] > work[j])
                            {
                                canExecute = false;
                                break;
                            }
                        }

                        if (canExecute)
                        {
                            for (int j = 0; j < instance; j++)
                            {
                                work[j] += allocation[i, j];
                            }

                            safeSequence[count] = i;
                            finish[i] = true;
                            count++;
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    break;
                }
            }
            // kiem tra an toan
            if (count == process)
            {
                Console.WriteLine("Thu tu thuc hien cac tien trinh: ");

                for (int i = 0; i < process; i++)
                {
                    Console.Write("P{0} ", safeSequence[i] + " ");
                }
                Console.WriteLine();
                return true;

            }
            else
            {
                Console.WriteLine("Khong an toan");
                return false;
            }
        }
    }
}
