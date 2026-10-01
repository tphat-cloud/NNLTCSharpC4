using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // ==========================================
    // KHAI BÁO CLASS DỮ LIỆU (Bài 4.1 & Bài 6.1)
    // ==========================================
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
    }

    public static class DuLieu
    {
        public static List<MonHoc> DS_Mon() => new List<MonHoc>
        {
            new MonHoc { MaMon = "HP2 1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP2 2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP3 1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP3 2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP4 1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP4 2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP5 1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "HP5 2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
            new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
            new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
            new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
            new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
            new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
            new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
            new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
            new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
            new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
            new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
        };

        public static List<He> DS_He() => new List<He>
        {
            new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
            new He { MaHe = "CD", TenHe = "Chuyên đề" },
            new He { MaHe = "OT", TenHe = "Chứng chỉ quốc tế" }
        };
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Bai21();
            Bai22();
            Bai31();
            Bai32();
            Bai51();
            Bai52();
            Bai62();
        }

        // ==========================================
        // BÀI 2.1: Truy vấn mảng số nguyên
        // ==========================================
        static void Bai21()
        {
            Console.WriteLine("\n=== BÀI 2.1: TRUY VẤN MẢNG SỐ NGUYÊN ===");
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // a. Chia hết cho 4 và 3
            var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
            Console.WriteLine("a. Phần tử chia hết cho 4 và 3: " + string.Join(", ", cauA));

            // b. Nhỏ hơn hoặc bằng 3
            var cauB = mangSo.Where(x => x <= 3);
            Console.WriteLine("b. Phần tử <= 3: " + string.Join(", ", cauB));

            // c. Số chẵn chia đôi, số lẻ giữ nguyên
            var cauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
            Console.WriteLine("c. Dãy mới (chẵn / 2, lẻ giữ nguyên): " + string.Join(", ", cauC));
        }

        // ==========================================
        // BÀI 2.2: Truy vấn mảng chuỗi
        // ==========================================
        static void Bai22()
        {
            Console.WriteLine("\n=== BÀI 2.2: TRUY VẤN MẢNG CHUỖI ===");
            string[] mangChuoi = { "đầu", "lòng", "hai", " ", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thủy", "Vân" };

            // a. 4 ký tự và sắp xếp tăng dần theo ký tự đầu
            var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
            Console.WriteLine("a. Chuỗi 4 ký tự, tăng dần ký tự đầu: " + string.Join(", ", cauA));

            // b. Biến đổi dạng: <chữ thường> - <CHỮ HOA>
            var cauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
            Console.WriteLine("b. Chữ thường - CHỮ HOA:\n   " + string.Join("\n   ", cauB));

            // c. Chứa ký tự 'u' hoặc 'U'
            var cauC = mangChuoi.Where(s => s.Contains("u", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("c. Phần tử chứa 'u': " + string.Join(", ", cauC));

            // d. Chọn các phần tử viết hoa ký tự đầu
            var cauD = mangChuoi.Where(s => !string.IsNullOrWhiteSpace(s) && char.IsUpper(s[0]));
            Console.WriteLine("d. Từ bắt đầu bằng chữ in hoa: " + string.Join(" ", cauD));
        }

        // ==========================================
        // BÀI 3.1: Thống kê mảng số
        // ==========================================
        static void Bai31()
        {
            Console.WriteLine("\n=== BÀI 3.1: THỐNG KÊ MẢNG SỐ ===");
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            // a. Đếm
            Console.WriteLine($"a. Tổng phần tử: {mangSo.Length}, Chẵn: {mangSo.Count(x => x % 2 == 0)}, Lẻ: {mangSo.Count(x => x % 2 != 0)}");

            // b. Sum, Max, Min
            Console.WriteLine($"b. Tổng: {mangSo.Sum()}, Max: {mangSo.Max()}, Min: {mangSo.Min()}");

            // c. Số giá trị khác nhau
            Console.WriteLine($"c. Số giá trị khác nhau: {mangSo.Distinct().Count()}");

            // d. Phân nhóm theo số dư khi chia 5
            Console.WriteLine("d. Phân nhóm theo số dư chia 5:");
            var cauD = mangSo.GroupBy(x => x % 5);
            foreach (var g in cauD)
            {
                Console.WriteLine($"   Số dư {g.Key}: {string.Join(", ", g)}");
            }
        }

        // ==========================================
        // BÀI 3.2: Thống kê mảng chuỗi
        // ==========================================
        static void Bai32()
        {
            Console.WriteLine("\n=== BÀI 3.2: THỐNG KÊ MẢNG CHUỖI ===");
            string[] monAn = {
                "Nước Cà phê", "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu",
                "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang"
            };

            // a. Chiều dài ngắn nhất và dài nhất
            int minLen = monAn.Min(s => s.Length);
            int maxLen = monAn.Max(s => s.Length);
            Console.WriteLine("a. Ngắn nhất: " + string.Join(", ", monAn.Where(s => s.Length == minLen)));
            Console.WriteLine("   Dài nhất: " + string.Join(", ", monAn.Where(s => s.Length == maxLen)));

            // b. Phân nhóm theo từ đầu tiên
            Console.WriteLine("b. Phân nhóm theo từ đầu tiên:");
            var cauB = monAn.GroupBy(s => s.Split(' ')[0]);
            foreach (var g in cauB)
            {
                Console.WriteLine($"   [{g.Key}]: {string.Join(", ", g)}");
            }

            // c. Đếm món có từ đầu tiên là "Bánh"
            Console.WriteLine($"c. Số phần tử bắt đầu bằng 'Bánh': {monAn.Count(s => s.StartsWith("Bánh"))}");
        }

        // ==========================================
        // BÀI 5.1: Truy vấn List<MonHoc> cơ bản
        // ==========================================
        static void Bai51()
        {
            Console.WriteLine("\n=== BÀI 5.1: TRUY VẤN LIST<MONHOC> CƠ BẢN ===");
            var listMon = DuLieu.DS_Mon();

            // a. Tên bắt đầu bằng "Lập trình"
            Console.WriteLine("a. Môn bắt đầu bằng 'Lập trình':");
            var cauA = listMon.Where(m => m.TenMon.StartsWith("Lập trình"));
            foreach (var m in cauA) Console.WriteLine($"   - {m.TenMon}");

            // b. Hệ "CD", số tiết giảm dần, mã môn tăng dần
            Console.WriteLine("b. Hệ CD (Tiết giảm dần, Mã môn tăng dần):");
            var cauB = listMon.Where(m => m.He == "CD")
                              .OrderByDescending(m => m.SoTiet)
                              .ThenBy(m => m.MaMon);
            foreach (var m in cauB) Console.WriteLine($"   [{m.MaMon}] {m.TenMon} - {m.SoTiet} tiết");

            // c. Tên chứa "web", chỉ lấy Tên môn và Hệ
            Console.WriteLine("c. Môn chứa từ 'web':");
            var cauC = listMon.Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                              .Select(m => new { m.TenMon, m.He });
            foreach (var item in cauC) Console.WriteLine($"   {item.TenMon} ({item.He})");

            // d. Hệ "KTV", tăng dần theo Mã môn
            Console.WriteLine("d. Hệ KTV tăng dần theo Mã môn:");
            var cauD = listMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon);
            foreach (var m in cauD) Console.WriteLine($"   [{m.MaMon}] {m.TenMon}");
        }

        // ==========================================
        // BÀI 5.2: Thống kê trên List<MonHoc>
        // ==========================================
        static void Bai52()
        {
            Console.WriteLine("\n=== BÀI 5.2: THỐNG KÊ TRÊN LIST<MONHOC> ===");
            var listMon = DuLieu.DS_Mon();

            // a & b & c
            Console.WriteLine($"a. Tổng số môn: {listMon.Count}");
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {listMon.Count(m => m.TenMon.StartsWith("Lập trình"))}");
            Console.WriteLine($"c. Tổng số tiết hệ KTV: {listMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet)}");

            // d. Tổng số môn của mỗi hệ
            Console.WriteLine("d. Tổng số môn của mỗi hệ:");
            var cauD = listMon.GroupBy(m => m.He).Select(g => new { He = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key, Tong = g.Count() });
            foreach (var item in cauD) Console.WriteLine($"   Hệ {item.He}: {item.Tong} môn");

            // e. Nhóm theo Số tiết, sắp xếp giảm dần theo Số tiết
            Console.WriteLine("e. Số môn theo số tiết (giảm dần):");
            var cauE = listMon.GroupBy(m => m.SoTiet)
                              .Select(g => new { SoTiet = g.Key, Tong = g.Count() })
                              .OrderByDescending(x => x.SoTiet);
            foreach (var item in cauE) Console.WriteLine($"   {item.SoTiet} tiết: {item.Tong} môn");

            // f. Môn có số tiết cao nhất
            byte maxTiet = listMon.Max(m => m.SoTiet);
            Console.WriteLine("f. Môn có số tiết cao nhất:");
            foreach (var m in listMon.Where(m => m.SoTiet == maxTiet))
                Console.WriteLine($"   [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)");

            // g. Thống kê theo Hệ (Tổng môn, tổng tiết, max, min)
            Console.WriteLine("g. Thống kê chi tiết theo Hệ:");
            var cauG = listMon.GroupBy(m => m.He).Select(g => new {
                He = string.IsNullOrEmpty(g.Key) ? "Khác" : g.Key,
                TongMon = g.Count(),
                TongTiet = g.Sum(x => (int)x.SoTiet),
                MaxTiet = g.Max(x => x.SoTiet),
                MinTiet = g.Min(x => x.SoTiet)
            });
            foreach (var item in cauG)
                Console.WriteLine($"   Hệ {item.He}: {item.TongMon} môn | Tổng {item.TongTiet} tiết | Max: {item.MaxTiet} | Min: {item.MinTiet}");

            // h. Phân nhóm môn học theo Hệ
            Console.WriteLine("h. Các môn học phân nhóm theo Hệ:");
            foreach (var g in listMon.GroupBy(m => m.He))
            {
                Console.WriteLine($"   * Hệ {(string.IsNullOrEmpty(g.Key) ? "Chưa phân hệ" : g.Key)}:");
                foreach (var m in g) Console.WriteLine($"     - {m.TenMon}");
            }

            // i. Phân nhóm theo Số tiết và tăng dần theo Số tiết
            Console.WriteLine("i. Phân nhóm theo Số tiết (tăng dần):");
            foreach (var g in listMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
            {
                Console.WriteLine($"   * Nhóm {g.Key} tiết:");
                foreach (var m in g) Console.WriteLine($"     - {m.TenMon}");
            }

            // j. Hệ KTV phân nhóm theo HP2, HP3, HP4, HP5
            Console.WriteLine("j. Hệ KTV phân nhóm theo Học Phần:");
            var cauJ = listMon.Where(m => m.He == "KTV")
                              .GroupBy(m => m.MaMon.Split(' ')[0]);
            foreach (var g in cauJ)
            {
                Console.WriteLine($"   * Học phần {g.Key}:");
                foreach (var m in g.OrderBy(x => x.MaMon)) Console.WriteLine($"     - [{m.MaMon}] {m.TenMon}");
            }

            // k. Phân nhóm theo Hệ, chỉ lấy môn Số tiết > 40
            Console.WriteLine("k. Môn có số tiết > 40 phân nhóm theo Hệ:");
            var cauK = listMon.GroupBy(m => m.He);
            foreach (var g in cauK)
            {
                var mons = g.Where(m => m.SoTiet > 40).OrderBy(m => m.MaMon);
                if (mons.Any())
                {
                    Console.WriteLine($"   * Hệ {g.Key}:");
                    foreach (var m in mons) Console.WriteLine($"     - [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)");
                }
            }
        }

        // ==========================================
        // BÀI 6.2: Join và các toán tử tập hợp
        // ==========================================
        static void Bai62()
        {
            Console.WriteLine("\n=== BÀI 6.2: TRUY VẤN TÊN HAI NGUỒN DỮ LIỆU ===");
            var listMon = DuLieu.DS_Mon();
            var listHe = DuLieu.DS_He();

            // a. Join (Inner Join)
            Console.WriteLine("a. Inner Join (Tên hệ, Mã môn, Tên môn):");
            var cauA = from h in listHe
                       join m in listMon on h.MaHe equals m.He
                       select new { h.TenHe, m.MaMon, m.TenMon };
            foreach (var item in cauA) Console.WriteLine($"   [{item.TenHe}] {item.MaMon} - {item.TenMon}");

            // b. Left Outer Join (GroupJoin + DefaultIfEmpty)
            Console.WriteLine("\nb. Left Join (Bao gồm hệ chưa có môn):");
            var cauB = from h in listHe
                       join m in listMon on h.MaHe equals m.He into gj
                       from subMon in gj.DefaultIfEmpty()
                       select new {
                           TenHe = h.TenHe,
                           MaMon = subMon?.MaMon ?? "(Không có)",
                           TenMon = subMon?.TenMon ?? "(Không có)"
                       };
            foreach (var item in cauB) Console.WriteLine($"   [{item.TenHe}] {item.MaMon} - {item.TenMon}");

            // c. Hệ chưa có môn AND Môn chưa có hệ (Full Outer Join đơn giản hóa)
            Console.WriteLine("\nc. Hệ chưa có môn VÀ Môn chưa có hệ:");
            var heKhongMon = listHe.Where(h => !listMon.Any(m => m.He == h.MaHe))
                                  .Select(h => $"Hệ chưa có môn: {h.TenHe}");
            var monKhongHe = listMon.Where(m => !listHe.Any(h => h.MaHe == m.He))
                                  .Select(m => $"Môn chưa có hệ: {m.TenMon}");
            foreach (var item in heKhongMon.Concat(monKhongHe)) Console.WriteLine($"   - {item}");

            // d. Chỉ liệt kê những hệ chưa có môn và môn chưa có hệ
            Console.WriteLine("\nd. Chỉ liệt kê các phần tử không trùng khớp:");
            Bai62_SubQueryD(listMon, listHe);

            // e. 5 môn học đầu tiên có số tiết giảm dần
            Console.WriteLine("\ne. Top 5 môn có số tiết cao nhất:");
            var cauE = (from m in listMon
                        join h in listHe on m.He equals h.MaHe into gj
                        from subHe in gj.DefaultIfEmpty()
                        orderby m.SoTiet descending
                        select new {
                            TenHe = subHe?.TenHe ?? "Chưa rõ",
                            m.MaMon,
                            m.TenMon,
                            m.SoTiet
                        }).Take(5);
            foreach (var item in cauE)
                Console.WriteLine($"   [{item.TenHe}] {item.MaMon} - {item.TenMon} ({item.SoTiet} tiết)");

            // f. Tổng số môn học của mỗi hệ
            Console.WriteLine("\nf. Tổng số môn học của mỗi hệ:");
            var cauF = from h in listHe
                       join m in listMon on h.MaHe equals m.He into gj
                       select new { h.MaHe, h.TenHe, TongMon = gj.Count() };
            foreach (var item in cauF)
                Console.WriteLine($"   {item.MaHe} ({item.TenHe}): {item.TongMon} môn");

            // g. Bao nhiêu loại Số tiết khác nhau
            Console.WriteLine($"\ng. Số loại số tiết khác nhau: {listMon.Select(m => m.SoTiet).Distinct().Count()}");

            // h. Môn học đầu tiên có tên bắt đầu bằng "Lập trình"
            var cauH = listMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"h. Môn đầu tiên bắt đầu bằng 'Lập trình': {cauH?.TenMon ?? "Không tìm thấy"}");

            // i. Liệt kê môn theo hệ, đánh số thứ tự trong mỗi nhóm
            Console.WriteLine("\ni. Đánh số thứ tự môn học theo từng hệ:");
            var cauI = listMon.GroupBy(m => m.He);
            foreach (var g in cauI)
            {
                var tenHe = listHe.FirstOrDefault(h => h.MaHe == g.Key)?.TenHe ?? "Chưa phân hệ";
                Console.WriteLine($"   === Hệ {tenHe} ({g.Key}) ===");
                var itemsWithIndex = g.Select((m, index) => new { STT = index + 1, Mon = m });
                foreach (var item in itemsWithIndex)
                {
                    Console.WriteLine($"     {item.STT}. [{item.Mon.MaMon}] {item.Mon.TenMon}");
                }
            }
        }

        static void Bai62_SubQueryD(List<MonHoc> listMon, List<He> listHe)
        {
            var noMon = listHe.Where(h => !listMon.Any(m => m.He == h.MaHe))
                              .Select(h => $"Hệ thiếu môn: {h.TenHe} ({h.MaHe})");
            var noHe = listMon.Where(m => !listHe.Any(h => h.MaHe == m.He))
                             .Select(m => $"Môn thiếu hệ: {m.TenMon} ({m.MaMon})");

            foreach (var x in noMon.Concat(noHe)) Console.WriteLine($"   + {x}");
        }
    }
}
