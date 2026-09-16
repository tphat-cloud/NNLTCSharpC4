using System;

public class Bai03
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Nhập x, y và tính x^y
        Console.Write("Nhap so nguyen x: ");
        int x = int.Parse(Console.ReadLine()!);

        Console.Write("Nhap so nguyen y: ");
        int y = int.Parse(Console.ReadLine()!);

        double ketQua = Math.Pow(x, y);
        Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
    }
}