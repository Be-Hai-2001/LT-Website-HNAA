// ========================== Độ phức tạp của thuật toán ========================== //

using System.Diagnostics;

class Program
{
    static void ThuatToanCanDo()
    {
        for (double i = 0; i < 10000000000; i++) ;
        // Console.WriteLine("* ");
    }
    static void Main()
    {
        // int n = 10;

        // // Thuật toán 0(n)
        // Console.WriteLine("Thuật toán 0(n)");
        // for (int i = 0; i < n; i++)
        //     Console.WriteLine("* ");

        // // Thuật toán 0(n^2)
        // Console.WriteLine("Thuật toán 0(n^2)");
        // for (int i = 0; i < n; i++)
        // {
        //     for (int j = 0; j < n; j++)
        //         Console.WriteLine("* ");
        //     Console.WriteLine();
        // }
        // var start = DateTime.Now;
        // ThuatToanCanDo();
        // Console.WriteLine("Thời gian thực thi: " + (DateTime.Now - start).TotalMicroseconds);

        // 2 StopWatch
        // var stopWatch = Stopwatch.StartNew();
        // ThuatToanCanDo();
        // stopWatch.Stop();
        // Console.WriteLine($"Thời gian thực thi tính bằng stopWatch: {stopWatch.ElapsedMilliseconds}");

        // 3

        var timing = new Timing();
        timing.Start();
        ThuatToanCanDo();
        timing.Stop();

        Console.WriteLine("Thời gian CPU xử lý: " + timing.Duration.TotalMilliseconds + " ms");

    }
}

class Timing
{
    TimeSpan _start, _duration;
    public TimeSpan Duration => _duration;

    public void Start()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();

        _start = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
    }

    public void Stop()
    {
        _duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime - _start;
    }
}