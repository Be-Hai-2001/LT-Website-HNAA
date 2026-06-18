class CuaHang
{
    // Biến tĩnh: Lưu tổng số khách hàng của TẤT CẢ các cửa hàng
    // static dùng để tạo ra vùng nhớ tĩnh (Truy cập dữ liệu từ khi run file, không khởi tạo lại giá trị ban đầu khi class được new)
    // public int TongSoKhach = 0; // Nếu lưu như vậy mỗi khi class được khởi tạo thì TongSoKhach sẽ được gán lại = 0
    public static int TongSoKhach = 0;

    public string TenCuaHang;

    public CuaHang(string ten, int soKhachHang)
    {
        TenCuaHang = ten;
        // Mỗi khi có 1 cửa hàng mở, tổng số khách có thể tăng lên
        TongSoKhach += soKhachHang;
    }

    // Phương thức tĩnh: Được gọi thông qua tên lớp
    public static void InTongSoKhach()
    {
        Console.WriteLine("Tổng số khách hiện tại: " + TongSoKhach);
    }
}


class ThamTriThamSo
{
    public static void TangGiaTri(ref int x)
    {
        x += 10;
    }

    // Ví dụ về out
    public static void LayThongTin(out int namSinh)
    {
        namSinh = 2000; // Bắt buộc phải gán giá trị bên trong hàm
    }

    // Ví dụ về params
    public static void InDanhSachSo(params int[] danhSach)
    {
        foreach (int so in danhSach)
        {
            Console.Write(so + " ");
        }
    }
}

class MayTinh
{
    // Cùng tên phương thức là "TinhTong" nhưng tham số khác nhau

    // Phiên bản 1: Cộng 2 số nguyên
    public int TinhTong(int a, int b)
    {
        return a + b;
    }

    // Phiên bản 2: Cộng 3 số nguyên
    public int TinhTong(int a, int b, int c)
    {
        return a + b + c;
    }

    // Phiên bản 3: Cộng 2 số thập phân
    public double TinhTong(double a, double b)
    {
        return a + b;
    }
}


class TaiKhoanNganHang
{
    // Dữ liệu nội bộ bị giấu kín (private)
    private double _soDu;

    // Thuộc tính chỉ đọc (Read-Only Property): Chỉ có get, không có set
    public string SoTaiKhoan { get; }
    public TaiKhoanNganHang(string soTaiKhoan)
    {
        SoTaiKhoan = soTaiKhoan;
        _soDu = 0;
    }

    public double SoDu
    {
        get { return _soDu; }
        set
        {
            if (value >= 0)
                _soDu = value;
            else
                Console.WriteLine("Lỗi: Số dư không thể là số âm.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // ==================== Demo 01 ==================== //
        // CuaHang ch1 = new("Cơ sở 1", 20);
        // CuaHang ch2 = new("Cơ sở 2", 10);

        // // Gọi phương thức tĩnh thông qua tên lớp (không gọi qua ch1 hay ch2)
        // CuaHang.InTongSoKhach();

        // ==================== Demo 02 ==================== //
        // // Sử dụng ref: Biến đã được khởi tạo giá trị
        // int diem = 5;
        // ThamTriThamSo.TangGiaTri(ref diem);
        // Console.WriteLine(diem); // Kết quả: 15

        // // Sử dụng out: Biến chauw được khởi tạo giá trị
        // int nam;
        // ThamTriThamSo.LayThongTin(out nam);
        // Console.WriteLine(nam);

        // // Sử dụng params: Dùng để truyền một danh sách tham số
        // ThamTriThamSo.InDanhSachSo(1, 2, 3);
        // ThamTriThamSo.InDanhSachSo(10, 20, 30, 40, 50);

        // ==================== Demo 03 nạp chồng phương thức ==================== //
        // MayTinh mt = new MayTinh();
        // Console.WriteLine(mt.TinhTong(5, 10));       // Gọi phiên bản 1
        // Console.WriteLine(mt.TinhTong(5, 10, 15));   // Gọi phiên bản 2
        // Console.WriteLine(mt.TinhTong(2.5, 3.5));    // Gọi phiên bản 3

        // ==================== Demo 04 đóng gói dữ liệu ==================== //
        TaiKhoanNganHang tk = new TaiKhoanNganHang("123456789");

        // tk.SoTaiKhoan = "987654321"; // LỖI: Không thể gán vì là thuộc tính chỉ đọc
        Console.WriteLine("Số TK: " + tk.SoTaiKhoan);

        // Gán và đọc số dư thông qua Property
        tk.SoDu = 50000; // Gọi set
        Console.WriteLine("Số dư: " + tk.SoDu); // Gọi get

        tk.SoDu = -1000; // Gọi set nhưng sẽ bị báo lỗi do giá trị âm


    }
}