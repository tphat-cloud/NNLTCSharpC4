using System;
using System.Collections.Generic;

public class Bai17
{
    // Sinh ngẫu nhiên mảng 2D A[n x m] trong [10, 100][cite: 1]
    public static int[,] SinhMang2D(int n, int m)
    {
        int[,] A = new int[n, m];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                A[i, j] = rand.Next(10, 101);
        return A;
    }

    public static void InMang2D(int[,] A, int n, int m)
    {
        Console.WriteLine("Mảng 2D:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(A[i, j] + "\t");
            Console.WriteLine();
        }
    }

    public static void TachChanLe(int[,] A, int n, int m, out int[] mangChan, out int[] mangLe)
    {
        List<int> chan = new List<int>();
        List<int> le = new List<int>();

        foreach (var val in A)
        {
            if (val % 2 == 0) chan.Add(val);
            else le.Add(val);
        }

        mangChan = chan.ToArray();
        mangLe = le.ToArray();
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập n (hàng): "); int n = int.Parse(Console.ReadLine()!);
        Console.Write("Nhập m (cột): "); int m = int.Parse(Console.ReadLine()!);

        int[,] A = SinhMang2D(n, m);
        InMang2D(A, n, m);

        TachChanLe(A, n, m, out int[] chan, out int[] le);
        Console.WriteLine("Mảng số chẵn: " + string.Join(" ", chan));
        Console.WriteLine("Mảng số lẻ: " + string.Join(" ", le));
    }
}