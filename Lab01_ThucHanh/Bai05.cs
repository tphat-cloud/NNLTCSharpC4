using System;

public class Bai05
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        double x = 0, y = 0;
        bool daNhap = false;
        int chon = 0;

        // Vòng lặp Menu cho xử lý hai số thực x, y
        do
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
            Console.WriteLine("2. Tinh x^y");
            Console.WriteLine("3. Tinh can bac 2 cua x va y");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon chuc nang: ");

            if (!int.TryParse(Console.ReadLine(), out chon)) continue;

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap x: ");
                    double.TryParse(Console.ReadLine(), out x);
                    Console.Write("Nhap y: ");
                    double.TryParse(Console.ReadLine(), out y);
                    daNhap = true;
                    break;
                case 2:
                    if (!daNhap) { Console.WriteLine("Hãy chọn 1 để nhập x, y trước!"); break; }
                    Console.WriteLine($"{x}^{y} = {Math.Pow(x, y)}");
                    break;
                case 3:
                    if (!daNhap) { Console.WriteLine("Hãy chọn 1 để nhập x, y trước!"); break; }
                    Console.WriteLine("Căn x: " + (x >= 0 ? Math.Sqrt(x).ToString() : "x < 0"));
                    Console.WriteLine("Căn y: " + (y >= 0 ? Math.Sqrt(y).ToString() : "y < 0"));
                    break;
            }
        } while (chon != 4);
    }
}