using System;
public class Bai01
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // B1: Nhập đầy đủ họ và tên, rồi xuất ra màn hình console
        Console.Write("Nhập họ: ");
        string ho = Console.ReadLine();
        Console.Write("Nhập tên: ");
        string ten = Console.ReadLine();
        Console.WriteLine("Họ và tên đã nhập: " + ho + " " + ten);
    }
}