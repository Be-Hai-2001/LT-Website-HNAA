// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Danh sách liên kết dùng nhiều cho việc thêm dữ liệu ở đầu và cuối danh sách, duyêt nhanh chóng 
// Ví dụ như thêm mới hàng loạt đơn hàng nghìn dòng -> nó sẽ thêm và duyệt nhanh hơn danh sách list<>.
class Program
{
    // Hàm liệt kê các phần tử trong danh sách
    static void PrintList(LinkedList<string> list)
    {
        foreach (var item in list)
            Console.Write($" {item} ->");
        Console.WriteLine(" null");
    }

    // Hàm thêm phần tử vào giữa danh sách
    static void InserAfter(LinkedList<string> list, string valueToInsert, string valueAfter)
    {
        LinkedListNode<string>? nodeAfter = list.Find(valueAfter);
        if (nodeAfter != null)
        {
            list.AddAfter(nodeAfter, valueToInsert);
        }
    }

    // Hàm tìm kiểm tra phần tử cho trước
    static bool Contains(LinkedList<string> list, string value)
    {
        return list.Contains(value);
    }

    // Hàm xóa phần tử cho trước
    enum ViTriXoa
    {
        First,
        Last,
        TheoGiaTri
    }

    static bool DeleteNode(LinkedList<string> list, ViTriXoa viTri, string value = null)
    {
        if (list.Count == 0) return false;

        switch (viTri)
        {
            case ViTriXoa.First:
                list.RemoveFirst();
                return true;

            case ViTriXoa.Last:
                list.RemoveLast();
                return true;

            case ViTriXoa.TheoGiaTri:
                return list.Remove(value);

            default:
                return false;
        }
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Khởi tạo danh sách liên kết kiểu dữ liệu string
        LinkedList<string> list = new LinkedList<string>();

        // 2. Thêm phần tử vào đầu và cuối danh sách
        list.AddLast("An");    // Thêm vào cuối
        list.AddLast("Binh");  // Thêm vào cuối
        list.AddFirst("Huy");  // Thêm vào đầu

        // 3. Chèn phần tử vào giữa danh sách liên kết
        InserAfter(list, "An", "Minh"); // Chèn "Minh" sau "An"

        // 4. Tìm kiếm phần tử
        string value = "Minh";

        Console.WriteLine(
            Contains(list, value)
            ? "Đã tìm thấy 'Minh' trong danh sách liên kết!"
            : $"Không tìm thấy {value} trong danh sách liên kết!"
        );

        // 5. Duyệt qua các node xuất ra màn hình
        Console.WriteLine("Danh sách liên kết:");
        PrintList(list);

        // 6. Xóa phần tử
        DeleteNode(list, ViTriXoa.TheoGiaTri, "Minh"); // Xóa theo giá trị cụ thể
        DeleteNode(list, ViTriXoa.First, ""); // Xóa phần tử ở đầu danh sách
        DeleteNode(list, ViTriXoa.Last, ""); // Xóa phần tử ở cuối danh sách

        Console.WriteLine("\nDanh sách sau khi xóa:");
        PrintList(list);

    }
}