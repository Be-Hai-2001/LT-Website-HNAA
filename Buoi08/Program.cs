// Khai báo kiểu dữ liệu mới trên là sinh viên

#region Cấu trúc struct kiểu dữ liệu SinhVien
struct SinhVien
{
    public int Mssv;
    public string HoTen;
    public double DiemToan;
    public double DiemLy;
    public double DiemHoa;

    // public SinhVien(int mssv, string hoTen, double diemToan, double diemLy, double diemHoa)
    // {
    //     Mssv = mssv;
    //     HoTen = hoTen;
    //     DiemToan = diemToan;
    //     DiemLy = diemLy;
    //     DiemHoa = diemHoa;
    // }
}
#endregion

#region Location : thể hiện tham chiếu tham trị
struct Location
{
    public double X;
    public double Y;

    public Location(double x, double y)
    {
        X = x;
        Y = y;
    }
}
#endregion

class Program
{
    public static void Main()
    {
        #region Cấu trúc struct kiểu dữ liệu SinhVien
        // // Cách 1: phải có contructor mới sử dụng được từ khóa new(giá trị khởi tạo)
        // SinhVien sv1 = new(0306201123, "Nguyễn Minh Hải", 9, 8.5, 6.5);

        // // Cách 2:
        // SinhVien sv2;
        // sv2.Mssv = 0306301120;
        // sv2.HoTen = "Bùi Gia Huy";
        // sv2.DiemHoa = 9.0;
        // sv2.DiemLy = 7.5;
        // sv2.DiemLy = 8.3;

        // Console.WriteLine($"Sinh viên thứ nhất (sv1): Mssv: {sv1.Mssv} - Họ tên: {sv1.HoTen}");
        // Console.WriteLine($"Sinh viên thứ nhất (sv2): Mssv: {sv2.Mssv} - Họ tên: {sv2.HoTen}");
        #endregion

        #region Location : thể hiện tham chiếu tham trị
        Location myLoc = new Location();
        myLoc.X = 50;

        Console.WriteLine($"Trước khi gọi hàm, myLoc.X = {myLoc.X}");

        // Gọi hàm và truyền struct vào
        ModifyLocation(myLoc);

        // Kiểm tra lại biến gốc
        // Vì Location là struct -> chỉ là bản sao -> không ảnh hưởng gốc
        Console.WriteLine($"Sau khi gọi hàm, myLoc.X = {myLoc.X}");
        #endregion

    }

    #region Location : thể hiện tham chiếu tham trị
    public static void ModifyLocation(Location loc)
    {
        loc.X = 99;
        Console.WriteLine($"Bên trong hàm ModifyLocation, loc.X= {loc.X}");
    }
    #endregion
}