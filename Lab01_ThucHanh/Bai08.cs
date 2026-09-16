using System;

public class Bai08
{
    // Phương thức hoán vị hai số thực dùng tham chiếu ref
    public static void HoanVi(ref double a, ref double b)
    {
        double temp = a;
        a = b;
        b = temp;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Nhập hai số thực a và b từ bàn phím
        Console.Write("Nhập số thực a: ");
        double a = double.Parse(Console.ReadLine()!);

        Console.Write("Nhập số thực b: ");
        double b = double.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nTrước hoán vị: a = {a}, b = {b}");

        // Gọi phương thức HoanVi (phải có từ khóa ref khi truyền tham số)
        HoanVi(ref a, ref b);

        Console.WriteLine($"Sau hoán vị:   a = {a}, b = {b}");
    }
}