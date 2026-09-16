using System;
using System.Linq;

public class Bai11
{
    // Phương thức thành viên trả về chuỗi đảo[cite: 1]
    public static string DaoChuoi(string str)
    {
        if (string.IsNullOrEmpty(str)) return "";
        return new string(str.Reverse().ToArray());
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập chuỗi: ");
        string s = Console.ReadLine();
        Console.WriteLine("Chuỗi sau khi đảo: " + DaoChuoi(s));
    }
}