using System;
public class Bai01
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // B1: Nhập họ tên và xuất ra màn hình console
        Console.WriteLine("Nhập họ tên: ");
        string hoTen = Console.ReadLine();
        Console.WriteLine("Họ tên đã nhập: " + hoTen);
    }
}