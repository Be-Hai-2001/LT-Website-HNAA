// ================================= CẤU TRÚC ĐỆ QUY ================================= // 

public class Program()
{
    static void Main()
    {
        int n = 4;
        Console.WriteLine($"Tính giai thừa của {n}!: " + GiaThua(n));
        Console.WriteLine($"Fibonacci {n}: " + Fibonacci(n));
        Console.WriteLine(IsOdd(n) ? $"{n} là số chẵn" : $"{n} là số lẽ");
    }

    // Đệ quy tuyến tính
    static int GiaThua(int n)
    {
        if (n == 0) return 1;
        return n * GiaThua(n - 1);
    }

    // Đệ quy nhị phân
    static int Fibonacci(int n)
    {
        if (n == 0 || n == 1) return n;

        // Gọi lại chính nó 2 lần
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // Đệ quy tương hổ
    static bool IsEven(int n)
    {
        if (n == 0) return true;
        return IsOdd(n - 2);
    }
    static bool IsOdd(int n)
    {
        if (n == 0) return false;
        return IsEven(n - 2);
    }
}