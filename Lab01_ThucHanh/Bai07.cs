using System;

public class Bai07
{
    // Phương thức bool kiểm tra số nguyên tố
    public static bool KiemTraSNT(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập n: ");
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"{n} có phải số nguyên tố? " + KiemTraSNT(n));
    }
}