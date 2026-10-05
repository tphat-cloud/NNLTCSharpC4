using Xunit;
using MyLib; // Nối tới thư viện để test

namespace MyLib.Tests
{
    public class LibBaiTapTests
    {
        // Test trường hợp có 2 nghiệm phân biệt (x^2 - 3x + 2 = 0)
        [Fact]
        public void Test_CoHaiNghiemPhanBiet()
        {
            double a = 1, b = -3, c = 2;
            string result = LibBaiTap.GiaiPTBac2(a, b, c);
            
            // Kiểm tra xem kết quả có chứa chữ "2 nghiệm phân biệt" không
            Assert.Contains("2 nghiệm phân biệt", result);
        }

        // Test trường hợp vô nghiệm (x^2 + 1 = 0)
        [Fact]
        public void Test_VoNghiem()
        {
            double a = 1, b = 0, c = 1;
            string result = LibBaiTap.GiaiPTBac2(a, b, c);

            // Kiểm tra xem có đúng là trả về "Phương trình vô nghiệm" không
            Assert.Equal("Phương trình vô nghiệm", result);
        }
    }
}
