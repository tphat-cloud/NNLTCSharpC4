using System;

public class Bai06
{
    // Hàm return tìm giá trị lớn nhất trong 3 số nguyên
    public static int TimMax(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        return max;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Nhập 3 số nguyên từ bàn phím
        Console.Write("Nhập số nguyên thứ nhất (a): ");
        int a = int.Parse(Console.ReadLine()!);

        Console.Write("Nhập số nguyên thứ hai (b): ");
        int b = int.Parse(Console.ReadLine()!);

        Console.Write("Nhập số nguyên thứ ba (c): ");
        int c = int.Parse(Console.ReadLine()!);

        // Gọi hàm tìm max và xuất kết quả
        int max = TimMax(a, b, c);
        Console.WriteLine($"Số lớn nhất trong 3 số ({a}, {b}, {c}) là: {max}");
    }
}