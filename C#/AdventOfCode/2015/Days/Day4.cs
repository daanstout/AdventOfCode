using System.Security.Cryptography;
using System.Text;

namespace _2015.Days;

public class Day4 : AdventDay {
    public Day4() : base(4, 2015, "The Ideal Stocking Stuffer") { }

    protected override object SolvePart1() {
        for(int i = 1; i < int.MaxValue; i++) {
            var md5Raw = Input + i;
            var md5 = MD5.HashData(Encoding.UTF8.GetBytes(md5Raw));
            var hex = Convert.ToHexString(md5);
            if (hex.StartsWith("00000")) {
                return i;
            }
        }
        return -1;
    }

    protected override object SolvePart2() {
        for (int i = 1; i < int.MaxValue; i++) {
            var md5Raw = Input + i;
            var md5 = MD5.HashData(Encoding.UTF8.GetBytes(md5Raw));
            var hex = Convert.ToHexString(md5);
            if (hex.StartsWith("000000")) {
                return i;
            }
        }
        return -1;
    }
}
