using System;

namespace Cau_Truc_lenh_Co_ban
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Nhập tên của bạn: ");
            // string name = Console.ReadLine() ?? "";

            // Console.Write("Nhập tuổi của bạn: ");
            // int age = int.Parse(Console.ReadLine() ?? "0");

            // Console.WriteLine("Xin chào, " + name + ". Bạn năm nay " + age + " tuổi.");

            // Console.WriteLine("Nhập số nguyên a: ");
            // int a = Convert.ToInt32(Console.ReadLine());

            // Console.WriteLine("Nhập số nguyên b: ");
            // int b = Convert.ToInt32(Console.ReadLine());

            // if (a > b)
            // {
            //     Console.WriteLine("Số nguyên lớn nhất là a");
            // }
            // else if (a < b)
            // {
            //     Console.WriteLine("Số nguyên lớn nhất là b");
            // }
            // else
            // {
            //     Console.WriteLine("Hai số nguyên bằng nhau.");
            // }

            // =============================== SWITCH CASE =============================== //

            // Console.WriteLine("Nhập ngày trong tuần (1-7): ");
            // int day = int.TryParse(Console.ReadLine(), out int parsedDay) ? parsedDay : 0;
            // int day = int.Parse(Console.ReadLine() ?? "0");

            // switch (day)
            // {
            //     case 1:
            //         Console.WriteLine("Hôm nay là thứ Hai.");
            //         break;
            //     case 2:
            //         Console.WriteLine("Hôm nay là thứ Ba.");
            //         break;
            //     case 3:
            //         Console.WriteLine("Hôm nay là thứ Tư.");
            //         break;
            //     case 4:
            //         Console.WriteLine("Hôm nay là thứ Năm.");
            //         break;
            //     case 5:
            //         Console.WriteLine("Hôm nay là thứ Sáu.");
            //         break;
            //     case 6:
            //         Console.WriteLine("Hôm nay là thứ Bảy.");
            //         break;
            //     case 7:
            //         Console.WriteLine("Hôm nay là Chủ Nhật.");
            //         break;
            //     default:
            //         Console.WriteLine("Ngày không hợp lệ. Vui lòng nhập số từ 1 đến 7.");
            //         break;
            // }

            // =============================== LOOP =============================== /

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Số: " + i);
            }

        }
    }
}