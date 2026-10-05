using System;
using System.Collections.Generic;

// ==================== PHẦN 1: LỚP MẢNG 2 CHIỀU ====================
public class Mang2D
{
    private int[,] a;

    public Mang2D()
    {
        a = new int[0, 0];
    }

    public Mang2D(int n, int m)
    {
        a = new int[n, m];
    }

    public Mang2D(Mang2D other)
    {
        int n = other.Hang;
        int m = other.Cot;
        a = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                a[i, j] = other.a[i, j];
    }

    public int Hang => a.GetLength(0);
    public int Cot => a.GetLength(1);

    public int this[int i, int j]
    {
        get => a[i, j];
        set => a[i, j] = value;
    }

    public void Input()
    {
        Console.Write("n (hàng) = ");
        int n = int.Parse(Console.ReadLine()!);
        Console.Write("m (cột) = ");
        int m = int.Parse(Console.ReadLine()!);
        a = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"a[{i},{j}] = ");
                a[i, j] = int.Parse(Console.ReadLine()!);
            }
        }
    }

    public void Output()
    {
        for (int i = 0; i < Hang; i++)
        {
            for (int j = 0; j < Cot; j++)
                Console.Write(a[i, j] + "\t");
            Console.WriteLine();
        }
    }

    private static bool LaSNT(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    public int[] SoNguyenTo()
    {
        List<int> ds = new List<int>();
        for (int i = 0; i < Hang; i++)
            for (int j = 0; j < Cot; j++)
                if (LaSNT(a[i, j])) ds.Add(a[i, j]);
        return ds.ToArray();
    }
}

// ==================== PHẦN 2: LỚP DÃY PHÂN SỐ ====================
public class DayPhanSo
{
    private List<PhanSo> ds = new List<PhanSo>();

    public void Nhap()
    {
        Console.Write("Nhập số lượng phân số n: ");
        int n = int.Parse(Console.ReadLine()!);
        ds.Clear();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"--- Phân số [{i + 1}] ---");
            PhanSo p = new PhanSo();
            p.Input();
            ds.Add(p);
        }
    }

    public void Xuat()
    {
        Console.WriteLine("Dãy phân số: " + string.Join(", ", ds));
    }

    public PhanSo TinhTong()
    {
        PhanSo tong = new PhanSo(0, 1);
        foreach (var p in ds)
        {
            tong += p;
        }
        return tong;
    }
}

// ==================== HÀM MAIN CHẠY THỬ CẢ 2 BÀI 2.4 ====================
public class Bai2_4
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== 1. THỰC HÀNH MẢNG 2 CHIỀU ===");
        Mang2D m = new Mang2D();
        m.Input();
        Console.WriteLine("--- Ma trận vừa nhập ---");
        m.Output();
        Console.WriteLine("Các số nguyên tố trong mảng: " + string.Join(" ", m.SoNguyenTo()));

        Console.WriteLine("\n=== 2. THỰC HÀNH DÃY PHÂN SỐ ===");
        DayPhanSo dps = new DayPhanSo();
        dps.Nhap();
        dps.Xuat();
        Console.WriteLine($"\n==> TỔNG DÃY PHÂN SỐ = {dps.TinhTong()}");
    }
}