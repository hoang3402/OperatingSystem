class Program
{
    private int iterations;
    private string message;
    static object _lock = new object();
    static private int _count = 0;

    public Program(int iterations, string message)
    {
        this.iterations = iterations;
        this.message = message;
    }
    public void Start(bool plus)
    {
        lock (_lock)
        {
            if (plus)
            {
                ThreadStart method = new ThreadStart(IncrementCount);
                Thread thread = new Thread(method);
                thread.Start();
                Console.WriteLine("{0} : Create new thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
            }
            else
            {
                ThreadStart method = new ThreadStart(DecrementCount);
                Thread thread = new Thread(method);
                thread.Start();
                Console.WriteLine("{0} : Create new thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
            }
        }
    }
    private void IncrementCount()
    {
        try
        {
            for (int i = 0; i < iterations; i++)
            {
                Monitor.Enter(_lock);
                _count++;
                Console.WriteLine("{0}: + Count = {1}", DateTime.Now.ToString("HH:mm:ss.ffff"), _count);
                Monitor.Pulse(_lock);
                Monitor.Wait(_lock);
            }
        }
        finally
        {
            Monitor.Pulse(_lock);
            Monitor.Exit(_lock);
        }

    }
    private void DecrementCount()
    {
        try
        {
            for (int i = 0; i < iterations; i++)
            {
                Monitor.Enter(_lock);
                _count--;
                Console.WriteLine("{0}: - Count = {1}", DateTime.Now.ToString("HH:mm:ss.ffff"), _count);
                Monitor.Pulse(_lock);
                Monitor.Wait(_lock);
            }
        }
        finally
        {
            Monitor.Pulse(_lock);
            Monitor.Exit(_lock);
        }
    }
    static void Main(string[] args)
    {
        Program p1 = new Program(2500, "");
        Program p2 = new Program(2500, "");
        p1.Start(true);
        p2.Start(false);
    }
}
