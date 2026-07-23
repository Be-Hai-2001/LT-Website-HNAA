// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

class Program
{
    static void Swap(ref int a, ref int b)
    {
        int temp = a; // Lưu tạm giá trị của a
        a = b;        // Gán giá trị b cho a
        b = temp;     // Gán giá trị tạm (của a ban đầu) cho b
    }

    // Sắp xếp Chèn (Insertion Sort)
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j; // Khai báo j ở đây

            // Vòng for làm nhiệm vụ dời các phần tử lớn hơn key sang phải
            for (j = i - 1; j >= 0 && arr[j] > key; j--)
            {
                arr[j + 1] = arr[j];
            }

            // chèn key vào đúng vị trí
            arr[j + 1] = key;
        }
    }

    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            int min = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[min])
                    min = j; // Cập nhật lại vị trí nhỏ nhất
            }

            Swap(ref arr[i], ref arr[min]);
        }
    }
    static void XuatMang(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
    }
    static void Main()
    {
        int[] arr = { 5, 4, 2, 7, 8, 1 };

        // InsertionSort(arr);

        SelectionSort(arr);

        XuatMang(arr);
    }
}