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

    //Sắp xếp chọn
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

    // Sắp xếp Nổi bọt (Bubble Sort)
    static void BubbleSorty(int[] arr)
    {
        int n = arr.Length;
        for (int i = n - 1; i >= 0; i--) // Vòng lặp chạy ngược về đầu

            for (int j = 1; j <= i; j++) // Vòng lặp chạy từ phần tử thứ i về cuối

                if (arr[j - 1] > arr[j]) // So sánh vị trí trước nó so với hiện tại ai lớn hơn
                    Swap(ref arr[j - 1], ref arr[j]);
    }

    // Hàm phân đoạn (Partition)
    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right]; // Chọn phần tử cuối cùng làm Pivot (Chốt)
        int i = left - 1;       // i là vị trí cuối cùng của nửa mảng <= Pivot

        for (int j = left; j < right; j++)
        {
            // Nếu phần tử hiện tại nhỏ hơn hoặc bằng chốt
            if (arr[j] <= pivot)
            {
                i++;
                Swap(ref arr[i], ref arr[j]); // Ném nó sang nửa bên trái
            }
        }
        // Cuối cùng, đưa chốt vào đúng vị trí ở giữa 2 nửa mảng
        Swap(ref arr[i + 1], ref arr[right]);
        return i + 1; // Trả về vị trí của chốt
    }

    // Sắp xếp Nhanh (Quick Sort)
    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int p = Partition(arr, left, right);

            QuickSort(arr, left, p - 1);
            QuickSort(arr, p + 1, right);
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

        // SelectionSort(arr);

        // BubbleSorty(arr);

        QuickSort(arr, 0, arr.Length - 1);

        XuatMang(arr);
    }
}