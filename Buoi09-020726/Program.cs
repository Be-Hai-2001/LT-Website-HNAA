
class TuoiKhongHopLeException : Exception
{
    public TuoiKhongHopLeException(string message) : base(message)
    {

    }
}
public class Program
{
    #region try-catch từ System có sẵn
    // static void Main()
    // {
    //     Console.WriteLine("-- CHƯƠNG TRÌNH CHIA HAI SỐ NGUYÊN --");

    //     try
    //     {
    //         Console.WriteLine("Nhập tử số: ");
    //         int tuSo = int.Parse(Console.ReadLine());

    //         Console.WriteLine("Nhập mẫu số: ");
    //         int mauSo = int.Parse(Console.ReadLine());

    //         Console.WriteLine($"Kết quả: {tuSo / mauSo}");

    //     }
    //     catch (System.Exception e)
    //     {
    //         Console.WriteLine($"Đã phát sinh lỗi: {e.Message}");
    //         Console.WriteLine($"Vị trí: {e.StackTrace}");
    //         // throw;
    //     }
    //     finally
    //     {
    //         Console.WriteLine("Kết thúc chương trình");
    //     }
    // }
    #endregion

    #region try-catch tự định nghĩa
    static void KiemTraTuoi(int tuoi)
    {
        if (tuoi < 18)
            throw new TuoiKhongHopLeException("Tuổi không hợp lệ");
    }

    static void Main()
    {

        try
        {
            Console.WriteLine("-- CHƯƠNG TRÌNH KIỂM TRA TUỔI --");
            Console.Write("Nhập tuổi: ");
            int tuoi = int.Parse(Console.ReadLine());
            KiemTraTuoi(tuoi);
        }
        catch (TuoiKhongHopLeException e)
        {
            Console.WriteLine("LỖI NGHIỆP VỤ: " + e.Message);
        }
    }
    #endregion
}