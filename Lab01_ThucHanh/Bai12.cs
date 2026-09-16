using System;

public class Bai12
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Nhập chuỗi nhiều từ, đổi chữ thường, chữ hoa và đếm từ[cite: 1]
        Console.Write("Nhập chuỗi: ");
        string input = Console.ReadLine();

        Console.WriteLine("Ký tự thường: " + input.ToLower());
        Console.WriteLine("Ký tự hoa: " + input.ToUpper());

        string[] cacTu = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Số từ trong chuỗi: " + cacTu.Length);
    }
}