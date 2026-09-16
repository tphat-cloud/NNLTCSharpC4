using System;

public class Bai16
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Sắp xếp mảng họ tên tăng dần[cite: 1]
        Console.Write("Nhập số người n: ");
        int n = int.Parse(Console.ReadLine()!);
        string[] hoTen = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Nhập tên người thứ {i + 1}: ");
            hoTen[i] = Console.ReadLine();
        }

        Array.Sort(hoTen); // Sắp xếp tăng dần

        Console.WriteLine("\nDanh sách họ tên sau sắp xếp:");
        foreach (var item in hoTen)
        {
            Console.WriteLine(item);
        }
    }
}