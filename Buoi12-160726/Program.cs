class Program
{
    // 1. Tìm kiếm tuần tự (Sequential Search)
    static int TimKiemTuanTu(int[] mang, int giaTriCanTim)
    {
        for (int i = 0; i < mang.Length; i++)
        {
            if (mang[i] == giaTriCanTim) // So sánh từng phần tử với giá trị cần tìm
            {
                return i; // Trả về vị trí (index) nếu tìm thấy
            }
        }
        return -1; // Trả về -1 nếu không tìm thấy
    }

    // 2. Tìm giá trị Lớn nhất / Nhỏ nhất(Min / Max)
    static int TimGiaTriLonNhat(int[] mang)
    {
        if (mang.Length == 0) throw new Exception("Mảng rỗng!");

        int max = mang[0];

        for (int i = 1; i < mang.Length; i++)
            if (mang[i] > max) max = mang[i];

        return max;
    }
    static void Main()
    {
        int[] data = { 5, 8, 2, 9, 3, 7 };
        int value = 9;

        // 1.Tìm kiếm tuần tự(Sequential Search)
        // int index = TimKiemTuanTu(data, value);

        // if (index != -1)
        //     Console.WriteLine($"Tìm thấy số {value} tại vị trí index = {index}");
        // else
        //     Console.WriteLine($"Không tìm thấy số {value} trong mảng.");

        // 2. Tìm giá trị Lớn nhất / Nhỏ nhất(Min / Max)cd
        Console.WriteLine($"Giá trị lớn nhất trong mảng là {TimGiaTriLonNhat(data)}");
    }