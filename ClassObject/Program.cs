// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Dynamic;

class HocSinh
{
    public string hoVaTen = string.Empty;
    public int tuoi;

    public void ChaoHoi()
    {
        Console.WriteLine("Xin chào cả lớp mình tên là " + hoVaTen);
    }

    public void KhaiBaoTuoi()
    {
        Console.WriteLine("Năm nay mình đã được " + tuoi);
    }
}

class Animal
{
    public string name = string.Empty;

    public Animal()
    {
        name = "Unknow Animal";
        Console.WriteLine(name);
    }

    public Animal(string nameAnimal)
    {
        name = nameAnimal;
        Console.WriteLine(name);
    }
}

class SinhVien
{
    private double diemToan;

    public double DiemToan
    {
        get
        {
            return diemToan;
        }

        set
        {
            if (value >= 0 && value <= 10)
                diemToan = value;
            else
                Console.WriteLine("Điểm không hợp lệ!");
        }
    }
}
class Program
{
    // 
    static void Main()
    {
        // HocSinh hs = new HocSinh();

        // hs.hoVaTen = "Nguyễn Minh Hải";
        // hs.tuoi = 24;

        // hs.ChaoHoi();
        // hs.KhaiBaoTuoi();

        // Animal dog = new();
        // // Console.WriteLine(dog);

        // Animal cat = new("Meo! Meo!");
        // // Console.WriteLine(cat);

        SinhVien sv = new SinhVien();
        sv.DiemToan = 100; // set
        sv.DiemToan = 10; // set

        Console.WriteLine("Điểm toán của tôi là: " + sv.DiemToan); //get
    }
}