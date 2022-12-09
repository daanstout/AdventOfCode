namespace _2021.Days;
public class Day10 : AdventDay {
    public Day10() : base(10, 2021, "Syntax Scoring") { }

    protected override object SolvePart1() {
        const string open = "{[(<";
        const string close = "}])>";

        const int scoreParenthesis = 3;
        const int scoreBrackets = 57;
        const int scoreBraces = 1197;
        const int scoreHooks = 25137;

        int[] scores = new int[] { scoreBraces, scoreBrackets, scoreParenthesis, scoreHooks };

        int score = 0;

        foreach(var line in Lines) {
            Stack<char> stack = new Stack<char>();

            foreach(var c in line) {
                if (open.Contains(c)) {
                    stack.Push(c);
                }else if (close.Contains(c)) {
                    var pop = stack.Pop();

                    if(open.IndexOf(pop) != close.IndexOf(c)) {
                        score += scores[close.IndexOf(c)];
                        break;
                    }
                }
            }
        }

        return score;
    }

    protected override object SolvePart2() {
        const string open = "{[(<";
        const string close = "}])>";

        const int scoreParenthesis = 1;
        const int scoreBrackets = 2;
        const int scoreBraces = 3;
        const int scoreHooks = 4;

        int[] scoreValues = new int[] { scoreBraces, scoreBrackets, scoreParenthesis, scoreHooks };

        List<long> scores = new();

        foreach (var line in Lines) {
            Stack<char> stack = new Stack<char>();
            bool isCorrupted = false;

            foreach (var c in line) {
                if (open.Contains(c)) {
                    stack.Push(c);
                } else if (close.Contains(c)) {
                    var pop = stack.Pop();

                    if (open.IndexOf(pop) != close.IndexOf(c)) {
                        isCorrupted = true;
                        break;
                    }
                }
            }

            if (!isCorrupted) {
                long score = 0;

                while(stack.Count > 0) {
                    score *= 5;

                    var c = stack.Pop();

                    score += scoreValues[open.IndexOf(c)];
                }

                scores.Add(score);
            }
        }

        scores.Sort();

        return scores[scores.Count / 2];
    }
}
