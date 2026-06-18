// 1. Đặc biệt hóa, Tổng quát hóa và Khai báo Kế thừa
class DongVatCoVu
{
    protected string Loai = "Động vật có vú";
    public void SinhSan()
    {
        Console.WriteLine("Sinh con và nuôi bằng sữa mẹ");
    }
}

class Meo : DongVatCoVu
{
    public string ten = "";

    public void BatChuot()
    {
        Console.WriteLine(Loai); // protected nên lớp ké thừa sử dụng được
        Console.WriteLine("Mèo đang bắt chuột.");
    }
}

// 2. Điều khiển truy xuất (protected vs private)
class NhanVien
{
    private readonly decimal _luongCoBan = 10000000000;
    protected string? maNhanVien;

    public decimal LayLuongCoBan()
    {
        return _luongCoBan;
    }
}

class QuanLy : NhanVien
{
    public void HienThiThongTin()
    {
        maNhanVien = "nv001";       // HỢP LỆ: Truy cập được biến protected của lớp cha
        Console.WriteLine("Mã nhân viên quản lý: " + maNhanVien);
        Console.WriteLine("Lương cơ bản: " + LayLuongCoBan());
    }
}

// 3. Gọi phương thức khởi tạo (Constructor) của lớp cơ sở bằng base
class People
{
    public string? FullName;

    // Contructor của lớp cha ( yêu cầu tham số truyền vào )
    public People(string fullName)
    {
        // FullName = fullName;
        Console.WriteLine("Bạn đã khởi tạo thành công People: " + FullName);
    }
}

class Student : People
{
    public double Diem;

    // Constructor của lớp con, dùng từ khóa : base() để truyền dữ liệu lên constructor lớp cha
    public Student(string fullName, double diem) : base(fullName)
    {
        Diem = diem;
        Console.WriteLine("Đã khởi tạo Student với điểm: " + Diem);
    }
}

// 4. Gọi phương thức của lớp cơ sở
class MayTinh
{
    public void KhoiDong()
    {
        Console.WriteLine("Máy tính đang load hệ điều hành...");
    }
}

class LapTop : MayTinh
{
    public void KhoiDongLapTop()
    {
        // Gọi laij logic phương thức KhoiDong() của lớp cha (MayTinh)
        base.KhoiDong();
        Console.WriteLine("Bật sáng màn hình laptop và kiểm tra dung lượng pin.");
    }
}
class Program
{
    static void Main()
    {
        // 1. Đặc biệt hóa, Tổng quát hóa và Khai báo Kế thừa
        // Meo cat = new();
        // // Console.WriteLine(cat.Loai); // protected không kế thừa nên không sử dụng được
        // cat.ten = "Chihuahua";
        // cat.BatChuot();
        // cat.SinhSan();

        // 2. Điều khiển truy xuất (protected vs private)
        // QuanLy quanLy = new();
        // quanLy.HienThiThongTin();

        // 3. Gọi phương thức khởi tạo (Constructor) của lớp cơ sở bằng base
        // Student student1 = new("Nguyễn Minh Hải", 8);
        // Student student2 = new("Lê Đình Hoan", 7);

        // 4. Gọi phương thức của lớp cơ sở
        LapTop lapTop = new();
        lapTop.KhoiDongLapTop();
    }
}