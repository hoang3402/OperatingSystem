class Program
{
    private int iterations;
    private string message;
    private int delay;
    static private int _count = 0;

    public Program(int iterations, string message, int delay)
    {
        this.iterations = iterations;
        this.message = message;
        this.delay = delay;
    }
    public void Start(bool plus)
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
    private void IncrementCount()
    {
        for (int i = 0; i < iterations; i++)
        {
            _count++;
            Console.WriteLine("{0}: + Count = {1}", DateTime.Now.ToString("HH:mm:ss.ffff"), _count);
            Thread.Sleep(delay);
        }

    }
    private void DecrementCount()
    {
        for (int i = 0; i < iterations; i++)
        {
            _count--;
            Console.WriteLine("{0}: - Count = {1}", DateTime.Now.ToString("HH:mm:ss.ffff"), _count);
            Thread.Sleep(delay);
        }
    }
    static void Main(string[] args)
    {
        Program p1 = new Program(2500, "", 1000);
        Program p2 = new Program(2500, "", 1000);
        p1.Start(true);
        p2.Start(false);
    }
}
