namespace OperatingSystem
{
    internal class Matrix
    {
        int rows;
        int columns;
        List<List<int>> matrix;

        public List<List<int>> GetMatrix { get => matrix; }

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new List<List<int>>();
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(new List<int>());
                for (int j = 0; j < columns; j++)
                {
                    matrix[i].Add(0);
                }
            }
        }

        public Matrix(List<List<int>> matrix)
        {
            this.rows = matrix.Count;
            this.columns = matrix[0].Count;
            this.matrix = matrix;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns != b.rows)
            {
                throw new Exception("Matrix dimensions do not match");
            }
            List<Thread> thread = new List<Thread>();
            Matrix result = new Matrix(a.rows, b.columns);

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    int iCopy = i;
                    int jCopy = j;
                    thread.Add(new Thread(() =>
                    {
                        for (int k = 0; k < a.columns; k++)
                        {
                            result.matrix[iCopy][jCopy] += a.matrix[iCopy][k] * b.matrix[k][jCopy];
                        }
                    }));
                    thread.Last().Start();
                }
            }
            // Wait
            foreach (Thread t in thread)
            {
                t.Join();
            }
            return result;
        }
    }
}
