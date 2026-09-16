using System;
using System.Linq;

public class Bai10
{
    // Phương thức thành viên kiểm tra chuỗi có đối xứng hay không[cite: 1]
    public static bool KiemTraDoiXung(string str)
    {
        if (string.IsNullOrEmpty(str)) return false;
        string dao = new string(str.Reverse().ToArray());
        return str.Equals(dao, StringComparison.OrdinalIgnoreCase);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập chuỗi: ");
        string s = Console.ReadLine();
        Console.WriteLine($"Chuỗi đối xứng: " + KiemTraDoiXung(s));
    }
}