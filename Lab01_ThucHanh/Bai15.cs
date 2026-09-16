using System;
using System.Collections.Generic;

public class Bai15
{
    // Các phương thức xử lý mảng 1D[cite: 1]
    public static void NhapMang(out int[] a)
    {
        Console.Write("Nhập số phần tử n: ");
        int n = int.Parse(Console.ReadLine()!);
        a = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            a[i] = int.Parse(Console.ReadLine()!);
        }
    }

    public static void InMang(int[] a)
    {
        Console.WriteLine("Mảng: " + string.Join(" ", a));
    }

    public static void TimMaxMin(int[] a)
    {
        int max = a[0], min = a[0];
        foreach (var x in a)
        {
            if (x > max) max = x;
            if (x < min) min = x;
        }
        Console.WriteLine($"Max = {max}, Min = {min}");
    }

    public static int[] LayMangSNT(int[] a)
    {
        List<int> dsSNT = new List<int>();
        foreach (var x in a)
        {
            if (Bai07.KiemTraSNT(x)) dsSNT.Add(x);
        }
        return dsSNT.ToArray();
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        NhapMang(out int[] a);
        InMang(a);
        TimMaxMin(a);
        int[] snt = LayMangSNT(a);
        Console.WriteLine("Các số nguyên tố trong mảng: " + string.Join(" ", snt));
    }
}