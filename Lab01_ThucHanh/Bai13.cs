using System;

// Lớp sinh viên lưu thông tin cơ bản[cite: 1]
class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public string DiaChi { get; set; }
    public int NamThuMay { get; set; }

    public void Nhap()
    {
        Console.Write("Mã SV: "); MaSV = Console.ReadLine();
        Console.Write("Họ tên: "); HoTen = Console.ReadLine();
        Console.Write("Địa chỉ: "); DiaChi = Console.ReadLine();
        Console.Write("Năm thứ mấy: "); NamThuMay = int.Parse(Console.ReadLine()!);
    }

    public void Xuat()
    {
        Console.WriteLine($"[SV] Ma: {MaSV} | Ten: {HoTen} | DiaChi: {DiaChi} | Nam: {NamThuMay}");
    }
}

public class Bai13
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        SinhVien sv = new SinhVien();
        sv.Nhap();
        sv.Xuat();
    }
}