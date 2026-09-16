using System;

public class Bai09
{
    // Tìm max và min của 3 số thực dùng tham chiếu out[cite: 1]
    public static void TimMaxMin(double a, double b, double c, out double max, out double min)
    {
        max = a; min = a;
        if (b > max) max = b;
        if (c > max) max = c;
        if (b < min) min = b;
        if (c < min) min = c;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Nhap 3 so thuc tu ban phim 
        Console.WriteLine("Nhap so thuc a: ");
        double a = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Nhap so thuc b: ");
        double b = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Nhap so thuc c: ");
        double c = double.Parse(Console.ReadLine()!);
        // Gọi phương thức (bắt buộc dùng từ khóa out cho biến nhận kết quả)
        TimMaxMin(a, b, c, out double max, out double min);
        Console.WriteLine($"Max = {max}, Min = {min}");
    }
}