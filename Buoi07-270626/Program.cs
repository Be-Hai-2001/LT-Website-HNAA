// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Nạp chồng phương thức
public class PhanSo
{
    public int MauSo { get; set; }
    public int TuSo { get; set; }

    public PhanSo(int tuSo, int mauSo)
    {
        TuSo = tuSo;

        MauSo = mauSo == 0 ? 1 : mauSo;
    }

    // Phương thức nạp chồng toán tử + với phân số
    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        int tuSoMoi = a.TuSo * b.MauSo + a.MauSo * b.TuSo;
        int mauSoMoi = a.MauSo * b.MauSo;

        return new PhanSo(tuSoMoi, mauSoMoi);
    }


    // Phương thức nạp chồng toán tử - với phân số
    public static PhanSo operator -(PhanSo a, PhanSo b)
    {
        int tuSoMoi = a.TuSo * b.MauSo - a.MauSo * b.TuSo;
        int mauSoMoi = a.MauSo * b.MauSo;

        return new PhanSo(tuSoMoi, mauSoMoi);
    }

    // Phương thức nạp chồng toán tử "Nhân" với phân số
    public static PhanSo operator *(PhanSo a, PhanSo b)
    {
        int tuSoMoi = a.TuSo * b.TuSo;
        int mauSoMoi = a.MauSo * b.MauSo;

        return new PhanSo(tuSoMoi, mauSoMoi);
    }


    // Phương thức nạp chồng toán tử "chia lấy nguyên" với phân số
    public static int operator /(PhanSo a, PhanSo b)
    {
        return (a.TuSo * b.MauSo) / (a.MauSo * b.TuSo);
    }


    // Phương thức nạp chồng toán tử "chia lấy nguyên" với phân số
    public static int operator %(PhanSo a, PhanSo b)
    {
        return (a.TuSo * b.MauSo) % (a.MauSo * b.TuSo);
    }

    //  Nạp chồng toán tử == với phân số
    public static bool operator ==(PhanSo a, PhanSo b)
    {
        // So sánh chéo: a.tu * b.mau == b.tu * a.mau
        return a.TuSo * b.MauSo == b.TuSo * a.MauSo;
    }

    // Nạp chồng toán tử != với phân số
    public static bool operator !=(PhanSo a, PhanSo b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not PhanSo other)
        {
            return false;
        }

        return TuSo * other.MauSo == other.TuSo * MauSo;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TuSo, MauSo);
    }

    public override string ToString()
    {
        return $"{TuSo}/{MauSo}";
    }

    // Chuyển đổi ngầm định (implicit) từ int sang PhanSo
    public static implicit operator PhanSo(int value)
    {
        // Ví dụ số 5 sẽ thành phân số 5/1
        return new PhanSo(value, 1);
    }

    // Chuyển đổi tường minh (explicit) từ PhanSo sang int
    public static explicit operator int(PhanSo f)
    {
        // Chỉ lấy phần nguyên của phép chia
        return f.TuSo / f.MauSo;
    }
}

class Program
{
    public static void Main()
    {
        PhanSo f1 = new(1, 2);
        PhanSo f2 = new(1, 2);

        // Ví dụ số 1
        int f3 = f1 % f2;
        Console.WriteLine($"Kết quả cộng: {f1} + {f2} = {f3}");

        // Ví dụ số 2
        // Console.WriteLine((f1 == f2) ? "Hai phân số bằng nhau" : "Hai phân số không bằng nhau");

        // Ví dụ số 3
        // 1. Chuyển đổi ngầm định (implicit)
        // PhanSo f = 5; // Tự động gọi hàm implicit, f sẽ mang giá trị 5/1

        // 2. Chuyển đổi tường minh (explicit)
        // int x = (int)f2; // Bắt buộc phải có (int) để ép kiểu. x sẽ mang giá trị 3

    }
}