class Program
{
    static void Main()
    {
        while (true)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==== MENU ĐỀ THI ====");
            Console.ResetColor();

            Console.WriteLine("1. Xây dựng project tam giác");
            Console.WriteLine("2. Xây dựng project học sinh");
            Console.WriteLine("3. Xây dựng project mảng số nguyên");
            Console.WriteLine("4. Xây dựng project danh sách số nguyên");

            Console.Write("\nThao tác chọn chức năng: ");
            ConsoleKeyInfo keyInfor = Console.ReadKey(true);

            switch (keyInfor.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("==== XÂY DỰNG PROJECT TAM GIÁC ====");
                    Console.ResetColor();

                    Console.Write("Nhập vào cạnh thứ nhất của tam giác: ");
                    double a = double.TryParse(Console.ReadLine(), out double resultA) ? resultA : 0;
                    Console.Write("Nhập vào cạnh thứ hai của tam giác: ");
                    double b = double.TryParse(Console.ReadLine(), out double resultB) ? resultB : 0;
                    Console.Write("Nhập vào cạnh thứ ba của tam giác: ");
                    double c = double.TryParse(Console.ReadLine(), out double resultC) ? resultC : 0;

                    TamGiac tamGiac = new(a, b, c);

                    if (tamGiac.IsTamGiac())
                    {
                        Console.WriteLine($"\nCác cạnh bạn vừa nhập thể hiện nó là một tam giác {tamGiac.KiemTraTamGiac()}");
                        Console.WriteLine($"Tam giác trên có chu vi là: {tamGiac.ChuVi()} | Diện tích là: {tamGiac.DienTich()}");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thao tác bất kì để quay lại menu Đề Thi..");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                case '2':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("==== XÂY DỰNG PROJECT HỌC SINH ====");
                    Console.ResetColor();

                    Console.Write("Nhập tên học sinh: ");
                    string tenHs = Console.ReadLine() ?? "";
                    Console.Write("Ngày sinh: ");
                    string ngSinh = Console.ReadLine() ?? "";
                    Console.Write("Điểm môn toán: ");
                    double dToan = double.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Điểm môn văn: ");
                    double dVan = double.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Điểm môn hóa: ");
                    double dHoa = double.Parse(Console.ReadLine() ?? "0");
                    Console.ResetColor();

                    HocSinh hocSinh = new(tenHs, dToan, dVan, dHoa, ngSinh);
                    Console.Clear();
                    hocSinh.XuatThongTin();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thao tác bất kì để chọn lại chức năng..");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                case '3':
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" ==== Xây dựng mảng số nguyên ====");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Nhập số lượng phần tử: ");
                    Console.ResetColor();
                    int n;

                    // Xử lý nhập n <= 0
                    Console.Write("Nhập số nguyên n (n > 0): ");
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên lớn hơn 0!");
                        Console.ResetColor();

                        Console.Write("Nhập lại n: ");
                    }

                    int[] arr = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write($"Nhập phần tử thứ {i + 1}: ");
                        arr[i] = int.TryParse(Console.ReadLine(), out int giaTri) ? giaTri : 0;
                    }

                    // -- Yêu cầu đề bài
                    MangSoNguyen mangSoNguyen = new(arr);

                    mangSoNguyen.XuatMang();

                    int giaTriTimKiem;
                    Console.Write("Nhập giá trị tìm kiếm: ");
                    while (!int.TryParse(Console.ReadLine(), out giaTriTimKiem))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ!");
                        Console.ResetColor();
                        Console.Write("Nhập lại giá trị cần tìm: ");
                    }

                    Console.WriteLine($"Tìm kiếm với thuật toán Tìm Kiếm Tuần Tự: {mangSoNguyen.TimKiemTuanTu(giaTriTimKiem)}");
                    Console.WriteLine($"Tìm kiếm với thuật toán Tìm Kiếm Nhị Phân: {mangSoNguyen.TimKiemNhiPhan(giaTriTimKiem)}");

                    // Sắp xếp chọn
                    Console.Write($"Sắp xếp chọn: ");
                    mangSoNguyen.SapXepChon();
                    mangSoNguyen.XuatMang();
                    Console.WriteLine();
                    // Sắp xếp chèn
                    Console.Write($"Sắp xếp chèn: ");
                    mangSoNguyen.SapXepChen();
                    mangSoNguyen.XuatMang();
                    Console.WriteLine();
                    // Sắp xếp nổi bọt
                    Console.Write($"Sắp xếp nổi bọt: ");
                    mangSoNguyen.SapXepNoiBot();
                    mangSoNguyen.XuatMang();
                    Console.WriteLine();
                    // Sắp xếp nhanh
                    Console.Write($"Sắp xếp nhanh: ");
                    mangSoNguyen.SapXepNhanh();
                    mangSoNguyen.XuatMang();
                    Console.WriteLine();

                    Console.ReadKey();
                    continue;
                case '4':
                    Console.Clear();
                    DanhSachSoNguyen dsSoNguyen = new();
                    while (true)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" ==== XÂY DỰNG DANH SÁCH SỐ NGUYÊN ====");
                        Console.ResetColor();

                        Console.WriteLine("[F2]: Thêm phần tử vào danh sách");
                        Console.WriteLine("[F12]: Xóa phần tử khỏi danh sách");
                        Console.WriteLine("[F4]: Xuất phần tử thứ index trong danh sách");
                        Console.WriteLine("[ESC]: Thoát chương trình");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nDanh sách số nguyên hiện tại là: ");
                        Console.ResetColor();
                        if (dsSoNguyen.DanhSach.Count == 0)
                            Console.WriteLine("#");
                        else
                        {
                            foreach (var item in dsSoNguyen.DanhSach)
                                Console.Write($"{item} ");
                            Console.Write(" #");
                            Console.WriteLine();
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\nChọn chức năng: ");

                        Console.ResetColor();
                        ConsoleKeyInfo keyFuntion = Console.ReadKey(true);

                        switch (keyFuntion.Key)
                        {
                            case ConsoleKey.F2:
                                Console.Clear();
                                dsSoNguyen.ThemPhanTu();
                                Console.Clear();
                                continue;
                            case ConsoleKey.F12:
                                if (dsSoNguyen.DanhSach.Count == 0)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Danh sách rỗng, không thể xóa phần tử!");
                                    Console.ResetColor();
                                    Console.WriteLine("Thao tác bất kì để chọn chức năng..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Danh sách hiện tai của bạn: [{string.Join(", ", dsSoNguyen.DanhSach)}]");
                                    Console.Write("Nhập giá trị cần xóa: ");
                                    int valueDelete = int.Parse(Console.ReadLine() ?? "0");
                                    if (dsSoNguyen.DanhSach.Contains(valueDelete))
                                    {
                                        dsSoNguyen.XoaPhanTu(valueDelete);
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Giá trị cần xóa không có trong danh sách!");
                                        Console.ResetColor();
                                        Console.WriteLine("Thao tác bất kì để chọn chức năng..");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }
                                }
                                break;
                            case ConsoleKey.F4:
                                Console.Clear();
                                if (dsSoNguyen.DanhSach.Count == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Danh sách rỗng");
                                    Console.ResetColor();
                                    Console.WriteLine("Thao tác bất kì để chọn lại chức năng..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("Nhập vị trí phần tử cần xem: ");
                                    int index = int.TryParse(Console.ReadLine(), out int resultIndex) ? resultIndex : -1;
                                    try
                                    {
                                        int valueAtIndex = dsSoNguyen.XuatPhanTu(index);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"Giá trị phần tử tại vị trí {index} là : {valueAtIndex}");
                                        Console.ResetColor();
                                        Console.WriteLine("Thao tác bất kì để chọn lại chức năng..");
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }

                                    catch (Exception e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        Console.WriteLine("Thao tác bất kì để chọn chức năng..");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        Console.Clear();
                                        continue;
                                    }
                                }

                            case ConsoleKey.Escape:
                                continue;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Lỗi: Lựa chọn của bạn không có trong chương trình!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Thao tác bất kì để chọn chức năng..");
                                Console.ResetColor();
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                        }
                    }
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Lỗi: Lựa chọn của bạn không có trong chương trình!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Thao tác bất kì để chọn chức năng..");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    continue;
            }
        }


    }

}

#region Bài 1: Xây dựng project tam giác
class TamGiac
{
    public double A, B, C;
    public TamGiac(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double ChuVi()
    {
        return Math.Round((A + B + C), 2);
    }

    public double DienTich()
    {
        double P = ChuVi();
        return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
    }

    public string KiemTraTamGiac()
    {
        // 1. Tam giác đều: 3 cạnh bằng nhau
        if (A == B && B == C)
            return "Điều";
        // 2. Tam giác vuông hoặc vuông cân
        else if (_KiemTraVuong())
        {
            if (A == B || B == C || A == C)
                return "Vuông Cân";
            else
                return "Vuông";
        }
        // 3. Tam giác cân: 2 cạnh bằng nhau
        else if (A == B || B == C || A == C)
            return "Cân";
        // 4. Tam giác thường
        else
            return "Thường";
    }

    public bool IsTamGiac()
    {
        if (A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A))
            return true;
        return false;
    }

    // Hàm kiểm tra định lý Py-ta-go cho tam giác vuông
    private bool _KiemTraVuong()
    {
        // Dùng Math.Round hoặc sai số nhỏ để tránh lỗi số chấm động (double precision)
        double a2 = A * A;
        double b2 = B * B;
        double c2 = C * C;

        return Math.Abs(a2 + b2 - c2) < 1e-5 ||
               Math.Abs(a2 + c2 - b2) < 1e-5 ||
               Math.Abs(b2 + c2 - a2) < 1e-5;
    }
}

#endregion

#region Bài 2: Xây dựng project học sinh
class HocSinh
{
    public string Ten { get; set; }
    public string NgaySinh { get; set; }
    public double DiemToan { get; set; }
    public double DiemVan { get; set; }
    public double DiemHoa { get; set; }
    public HocSinh(string ten, double toan, double van, double hoa, string ngSinh)
    {
        Ten = ten;
        NgaySinh = ngSinh;

        DiemToan = toan;
        DiemVan = van;
        DiemHoa = hoa;
    }

    public double DiemTrungBinh()
    {
        return Math.Round((DiemToan + DiemVan + DiemHoa) / 3, 2);
    }

    public string XepLoaiHocLuc()
    {
        double dtb = DiemTrungBinh();

        if (dtb > 10 || dtb <= 0)
            return "Điểm trung bình không hợp lệ!";
        else if (dtb < 10 && dtb >= 8)
            return "Giỏi";
        else if (dtb >= 7)
            return "Khá";
        else if (dtb >= 5)
            return "Trung Bình";
        else
            return "Yếu";
    }

    public void XuatThongTin()
    {
        // Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"{Ten} - {NgaySinh}");
        Console.WriteLine($"Điểm toán: {DiemToan} | Điểm văn: {DiemVan} | Điểm hóa: {DiemHoa}");
        Console.WriteLine($"Điểm trung bình: {DiemTrungBinh()} | Xếp loại {XepLoaiHocLuc()}");
    }
}

#endregion

#region Bài 3: Xây dựng project mảng số nguyên
class MangSoNguyen
{
    public int[] Arr { get; set; }

    public MangSoNguyen(int[] arr)
    {
        Arr = arr;
    }

    public void XuatMang()
    {
        for (int i = 0; i < Arr.Length; i++)
            Console.Write($"{Arr[i]} ");

    }

    // Tìm kiếm nhị phân
    public int TimKiemNhiPhan(int giaTri)
    {
        int left = 0;
        int right = Arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Trung vị (giá trị cần tìm)

            if (giaTri == Arr[mid]) return mid; // Tìm thấy giá trị

            if (Arr[mid] < giaTri)
                left = mid + 1; // Tìm nữa kiếm bên phải
            else
                right = mid - 1; // Tìm nữa kiếm bên trái
        }

        // Không tìm thấy
        return -1;
    }

    // Tìm kiếm tuần tự
    public int TimKiemTuanTu(int giaTri)
    {
        for (int i = 0; i < Arr.Length; i++)
        {
            if (Arr[i] == giaTri) // So sánh từng phần tử với giá trị cần tìm
            {
                return i; // Trả về vị trí (index) nếu tìm thấy
            }
        }
        return -1; // Trả về -1 nếu không tìm thấy
    }

    // Sắp xếp mảng tăng dần
    static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }

    // Sắp xếp chọn (Selection Sort)
    public void SapXepChon()
    {
        for (int i = 0; i < Arr.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < Arr.Length; j++)
            {
                if (Arr[j] < Arr[min])
                    min = j;
            }
            Swap(ref Arr[i], ref Arr[min]);
        }
    }

    // Sắp xếp chèn (Insertion Sort)
    public void SapXepChen()
    {
        int n = Arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = Arr[i];
            int j = i - 1;

            while (j >= 0 && Arr[j] > key)
            {
                Arr[j + 1] = Arr[j];
                j = j - 1;
            }

            // Đặt key vào vị trí thích hợp đã tìm được
            Arr[j + 1] = key;
        }
    }

    // Sắp xếp nổi bọt (Bubble Sort)
    public void SapXepNoiBot()
    {
        int n = Arr.Length;
        bool swapped; // Cờ kiểm tra xem trong lượt duyệt có phát sinh hoán đổi không

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            // Vòng lặp bên trong: So sánh từng cặp phần tử kề nhau
            // Sau mỗi vòng i, phần tử lớn nhất đã ở đúng vị trí cuối nên giảm (n - 1 - i)
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (Arr[j] > Arr[j + 1])
                {
                    // Đổi chỗ 2 phần tử kề nhau
                    Swap(ref Arr[j], ref Arr[j + 1]);
                    swapped = true;
                }
            }

            // Tối ưu: Nếu không có hoán đổi nào xảy ra ở vòng này, mảng đã sắp xếp xong!
            if (!swapped) break;
        }
    }

    // Hàm gọi công khai để sắp xếp mảng
    public void SapXepNhanh()
    {
        if (Arr != null && Arr.Length > 0)
        {
            QuickSort(0, Arr.Length - 1);
        }
    }

    // Hàm đệ quy QuickSort chính
    private void QuickSort(int left, int right)
    {
        if (left >= right) return;

        // Phân hoạch mảng và lấy chỉ số vị trí chốt (pivot)
        int pivotIndex = Partition(left, right);

        // Đệ quy sắp xếp 2 nửa
        QuickSort(left, pivotIndex - 1);  // Nửa bên trái
        QuickSort(pivotIndex + 1, right); // Nửa bên phải
    }

    // Hàm phân hoạch (Partition) - Chọn phần tử ở giữa làm Pivot
    private int Partition(int left, int right)
    {
        int pivot = Arr[(left + right) / 2]; // Chọn phần tử giữa làm Pivot
        int i = left;
        int j = right;

        while (i <= j)
        {
            // Tìm phần tử bên trái lớn hơn hoặc bằng Pivot
            while (Arr[i] < pivot) i++;

            // Tìm phần tử bên phải nhỏ hơn hoặc bằng Pivot
            while (Arr[j] > pivot) j--;

            if (i <= j)
            {
                // Đổi chỗ 2 phần tử bị sai vị trí
                Swap(ref Arr[i], ref Arr[j]);
                i++;
                j--;
            }
        }

        return i - 1; // Trả về chỉ số phân chia
    }
}
#endregion

#region Bài 4: Xây dựng project danh sách số nguyên
class DanhSachSoNguyen
{
    public List<int> DanhSach = new();

    // Thêm phần tử vào danh sách
    public void ThemPhanTu()
    {
        Console.Write("Nhập giá trị cần thêm vào trong danh sách: ");
        int value = int.Parse(Console.ReadLine() ?? "0");
        DanhSach.Add(value);
    }

    // Xoa phần tử vào danh sách
    public void XoaPhanTu(int gt)
    {
        // Console.Write("Nhập giá trị cần xóa: ");
        // int gt = int.Parse(Console.ReadLine() ?? "0");
        DanhSach.Remove(gt);
    }
    //Xuất giá trị phần tử theo vị trí indexs
    public int XuatPhanTu(int viTri)
    {
        if (viTri >= 0 && viTri < DanhSach.Count)
            return DanhSach[viTri];
        else
            throw new IndexOutOfRangeException("Vị trí index không hợp lệ.");
    }
}
#endregion