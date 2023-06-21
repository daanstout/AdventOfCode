namespace _2021.Days;

public class Day4 : AdventDay {
    private class Digit {
        public int number;
        public bool marked;

        public override string ToString() => $"{number} - {(marked ? "1" : "0")}";
    }

    private class Board {
        public bool HasBingo => CalculateBingo();

        private readonly Digit[,] digits = new Digit[5, 5];
        private readonly Dictionary<int, Digit> digitByNumber = new();

        public Board(string[] digits, int boardStartIndex) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    string[] numbers = digits[i + boardStartIndex].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    this.digits[i, j] = new Digit() { number = int.Parse(numbers[j]) };
                    digitByNumber[this.digits[i, j].number] = this.digits[i, j];
                }
            }
        }

        public bool Mark(int number) {
            if (!digitByNumber.TryGetValue(number, out Digit? digit)) {
                return false;
            }

            digit.marked = true;

            return CalculateBingo();
        }

        public int GetScore(int hit) => digitByNumber.Values.Where(digit => !digit.marked).Select(digit => digit.number).Sum() * hit;

        private bool CalculateBingo() {
            return Enumerable.Range(0, 5).Any(i => digits.SliceRow(i).All(digit => digit.marked))
                || Enumerable.Range(0, 5).Any(i => digits.SliceColumn(i).All(digit => digit.marked));
        }
    }

    public Day4() : base(4, 2021, "Giant Squid") { }

    protected override object SolvePart1() {
        List<Board> boards = new List<Board>();

        for (int i = 2; i < Lines.Length; i += 6) {
            Board board = new Board(Lines, i);

            boards.Add(board);
        }

        string[] hits = Lines[0].Split(',');

        foreach (var hit in hits) {
            int number = int.Parse(hit);
            foreach (var board in boards) {
                if (board.HasBingo) {
                    continue;
                }

                if (board.Mark(number)) {
                    return board.GetScore(number);
                }
            }
        }

        return -1;
    }

    protected override object SolvePart2() {
        List<Board> boards = new List<Board>();

        for (int i = 2; i < Lines.Length; i += 6) {
            Board board = new Board(Lines, i);

            boards.Add(board);
        }

        string[] hits = Lines[0].Split(',');

        Board lastBoard = null!;
        int lastNumber = 0;

        foreach (var hit in hits) {
            int number = int.Parse(hit);
            foreach (var board in boards) {
                if (board.HasBingo) {
                    continue;
                }

                if (board.Mark(number)) {

                    lastBoard = board;
                    lastNumber = number;
                }
            }
        }

        return lastBoard.GetScore(lastNumber);
    }
}
