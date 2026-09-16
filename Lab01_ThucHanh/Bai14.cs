using System;

// Lớp nhân viên và tính lương trừ 100k/ngày vắng[cite: 1]
class NhanVien
{
    public string HoTen { get; set; }
    public double MucLuong { get; set; }
    public int SoNgayVang { get; set; }

    public double TinhLuong()
    {
        return MucLuong - (SoNgayVang * 100000);
    }

    public void Nhap()
    {
        Console.Write("Họ tên NV: "); HoTen = Console.ReadLine();
        Console.Write("Mức lương: "); MucLuong = double.Parse(Console.ReadLine()!);
        Console.Write("Số ngày vắng: "); SoNgayVang = int.Parse(Console.ReadLine()!);
    }

    public void Xuat()
    {
        Console.WriteLine($"Nhân viên: {HoTen} | Lương thực nhận: {TinhLuong():N0} VNĐ");
    }
}

public class Bai14
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        NhanVien nv = new NhanVien();
        nv.Nhap();
        nv.Xuat();
    }
}