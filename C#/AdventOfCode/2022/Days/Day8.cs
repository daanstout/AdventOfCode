namespace _2022.Days;

public class Day8 : AdventDay {
    public Day8() : base(8, 2022, "Treetop Tree House") { }

    protected override object SolvePart1() {
        var heightMap = Lines.ToHeightMap(out var width, out var height);

        int visible = width * 2 + height * 2 - 4;

        for (int y = 1; y < height - 1; y++) {
            for (int x = 1; x < width - 1; x++) {
                int current = heightMap[x, y];

                bool isVisible = true;

                for(int xStart = x - 1; xStart >= 0; xStart--) {
                    if (heightMap[xStart, y] >= current) {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible) {
                    visible++;
                    continue;
                }

                isVisible = true;

                for(int xStart = x + 1; xStart < width; xStart++) {
                    if (heightMap[xStart, y] >= current) {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible) {
                    visible++;
                    continue;
                }

                isVisible = true;

                for(int yStart = y - 1; yStart >= 0; yStart--) {
                    if (heightMap[x, yStart] >= current) {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible) {
                    visible++;
                    continue;
                }

                isVisible = true;

                for(int yStart = y + 1; yStart < height; yStart++) {
                    if (heightMap[x, yStart] >= current) {
                        isVisible = false;
                        break;
                    }
                }

                if (isVisible) {
                    visible++;
                }
            }
        }

        return visible;
    }

    protected override object SolvePart2() {
        var heightMap = Lines.ToHeightMap(out var width, out var height);

        List<int> scores = new();

        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                int score = 1;

                int current = heightMap[x, y];

                int offset = 0;
                bool broken = false;

                for(offset = 1; offset <= x; offset++) {
                    if (heightMap[x - offset, y] >= current) {
                        score *= offset;
                        broken = true;
                        break;
                    }
                }

                if (!broken) {
                    score *= offset - 1;
                }

                broken = false;

                for(offset = 1; offset < width - x; offset++) {
                    if (heightMap[x + offset, y] >= current) {
                        score *= offset;
                        broken = true;
                        break;
                    }
                }

                if (!broken) {
                    score *= offset - 1;
                }

                broken = false;

                for (offset = 1; offset <= y; offset++) {
                    if (heightMap[x, y - offset] >= current) {
                        score *= offset;
                        broken = true;
                        break;
                    }
                }

                if (!broken) {
                    score *= offset - 1;
                }

                broken = false;

                for (offset = 1; offset < height - y; offset++) {
                    if (heightMap[x, y + offset] >= current) {
                        score *= offset;
                        broken = true;
                        break;
                    }
                }

                if (!broken) {
                    score *= offset - 1;
                }

                scores.Add(score);
            }
        }

        return scores.Max();
    }
}
