using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019.Days;

public class Day4 : AdventDay {
    public Day4() : base(4, 2019, "Secure Container") { }

    protected override object SolvePart1() {
        var parts = Input.Split('-').ToIntArray();
        int count = 0;
        for (int i = parts[0]; i <= parts[1]; i++) {
            if (MeetsCriteriaOne(i.ToString())) {
                count++;
            }
        }

        return count;
    }

    protected override object SolvePart2() {
        var parts = Input.Split('-').ToIntArray();
        int count = 0;

        for (int i = parts[0]; i <= parts[1]; i++) {
            if (MeetsCriteriaTwo(i.ToString())) {
                count++;
            }
        }

        return count;
    }

    private static bool MeetsCriteriaOne(string password) {
        char lastChar = password[0];
        bool hasDouble = false;

        for (var i = 1; i < password.Length; i++) {
            var c = password[i];
            if (c < lastChar)
                return false;
            if (c == lastChar)
                hasDouble = true;
            lastChar = c;
        }

        return hasDouble;
    }

    private static bool MeetsCriteriaTwo(string password) {
        List<char> copy = new List<char>(password);
        copy.Sort();

        if (!password.SequenceEqual(copy)) {
            return false;
        }

        return copy.Any(c => copy.Count(ch => ch == c) == 2);
    }
}
