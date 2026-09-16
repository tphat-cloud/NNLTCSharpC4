using System;
public class Bai02
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Xuất họ tên theo định dạng chào hỏi
        Console.WriteLine("Nhap ho ten cua ban: ");
        string hoTen = Console.ReadLine();
        Console.WriteLine($"Chao ban {hoTen}");
    }
}