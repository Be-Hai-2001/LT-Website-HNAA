// =========================== Abstract ======================//

public abstract class Animal
{
    public string? Ten { get; set; }

    // funtion cho phép ghi đè bắt buộc các class  kế thừa phải có
    public abstract void speakAnimal();
}

// Lớp con ghi đè phương thức abstract có ở lớp cha
public class Dog : Animal
{
    // Lớp con đang ghi đè phương thức speakAnimal có ở lớp cha
    public override void speakAnimal()
    {
        Console.WriteLine("Tôi là con chó!");
    }
}

// Lớp con ghi đè phương thức abstract có ở lớp cha
public class Cat : Animal
{
    public override void speakAnimal()
    {
        Console.WriteLine("Tôi là con Mèo!");
    }
}
// =========================== With list (Shape) ======================//

abstract class Shape
{
    public abstract void Draw();
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Chào bạn tôi là: Circle");
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Chào bạn tôi là: Rectangle");
    }
}

// =========================== With list (SinhVien) ======================//

class SinhVien
{
    public string? Hoten { get; set; }
    public int Tuoi { get; set; }

    public override string ToString()
    {
        return $"Sinh viên: {Hoten}, tuoi: {Tuoi}";
    }
}

public class TruongHoc
{
    // public static string TenTruongHoc = "Cao Thang Technical College";
    public string TenTruongHoc = "Cao Thang Technical College";

    public class PhongBan
    {
        public string? TenPhongban { get; set; }
        public void HienThiPhongban()
        {
            // Console.WriteLine("Đây là phòng: " + TenPhongban + TenTruongHoc);
            Console.WriteLine("Đây là phòng: " + TenPhongban);
        }
    }
}
class Program
{
    static void Main()
    {
        // 1.
        // DongVat dv = new DongVat(); // LỖI: Không thể khởi tạo đối tượng từ lớp abstract
        // Thể hiện tính đa hình: Cùng là kiểu DongVat nhưng đối tượng thực tế khác nhau

        // Animal dog = new Dog();
        // Animal cat = new Cat();

        // dog.speakAnimal();
        // cat.speakAnimal();

        // 2.
        // Shape[] shapes = { new Circle(), new Rectangle() };

        // foreach (Shape shape in shapes)
        // {
        //     shape.Draw();
        // }

        // 3.
        // SinhVien sv1 = new SinhVien { Hoten = "Nguyễn Minh Hải", Tuoi = 24 };
        // SinhVien sv2 = new SinhVien { Hoten = "Bùi Gia Huy", Tuoi = 22 };

        // // GetType() để lấy ra kiểu dữ liệu
        // // Equals dùng để so sánh 2 object
        // Console.WriteLine(sv1.Tuoi.Equals(sv2.Tuoi) ? "Bằng tuổi" : "Khác tuổi");

        // 4.
        // int bienGiaTri = 100;
        // object hop = bienGiaTri;
        // Console.WriteLine("Giá trị trong hộp: " + hop);

        // int layGiaTri = (int)hop;
        // Console.WriteLine("Giá trị trong hộp: " + layGiaTri);

        // 5.
        TruongHoc.PhongBan ctcthssv = new TruongHoc.PhongBan { TenPhongban = "Công tác chính trị hssv" };
        TruongHoc.PhongBan daoTao = new() { TenPhongban = "Đào tạo học sinh sinh viên" };

        daoTao.HienThiPhongban();
    }
}