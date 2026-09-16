using System;

public class Bai04
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Kiểm tra ép kiểu với TryParse để báo lỗi nếu nhập sai số nguyên
        Console.Write("Nhap so nguyen x: ");
        string inputX = Console.ReadLine();

        Console.Write("Nhap so nguyen y: ");
        string inputY = Console.ReadLine();

        if (!int.TryParse(inputX, out int x) || !int.TryParse(inputY, out int y))
        {
            Console.WriteLine("Lỗi: x hoặc y không phải là số nguyên hợp lệ!");
            return;
        }

        Console.WriteLine($"Ket qua {x} mu {y} la: {Math.Pow(x, y)}");
    }
}