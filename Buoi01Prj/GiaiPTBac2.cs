using System;
using MyLib; // Gọi thư viện MyLib vừa viết ở trên ra xài

namespace Buoi01Prj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Để in tiếng Việt không lỗi

            Console.WriteLine("=== CHƯƠNG TRÌNH GIẢI PHƯƠNG TRÌNH BẬC 2 ===");

            Console.Write("Nhập a: ");
            double a = double.Parse(Console.ReadLine()!);

            Console.Write("Nhập b: ");
            double b = double.Parse(Console.ReadLine()!);

            Console.Write("Nhập c: ");
            double c = double.Parse(Console.ReadLine()!);

            // Lấy hàm từ MyLib ra tính toán
            string ketQua = LibBaiTap.GiaiPTBac2(a, b, c);

            Console.WriteLine("\nKẾT QUẢ: " + ketQua);
        }
    }
}
