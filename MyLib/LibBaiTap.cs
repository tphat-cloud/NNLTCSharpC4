namespace MyLib;

public class LibBaiTap
{
    public static string GiaiPTBac2(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0)
            {
                return (c==0) ? "Phuong trinh vo so nghiem": "Phuong trinh vo nghiem";
            }
            return $"Phuong trinh co 1 nghiem x = -c/b";
        }
        double delta = b*b - 4 * a * c;
        if (delta < 0)
            {
                return "Phương trình vô nghiệm";
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                return $"Phương trình có nghiệm kép: x = {x}";
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                return $"Phương trình có 2 nghiệm phân biệt: x1 = {x1}, x2 = {x2}";
            }
     }
 }
