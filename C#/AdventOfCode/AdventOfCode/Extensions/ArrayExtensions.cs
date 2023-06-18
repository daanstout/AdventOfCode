namespace AdventOfCode;

public static class ArrayExtensions {
    public static IEnumerable<T> SliceRow<T>(this T[,] array, int row) {
        for (int i = 0; i < array.GetLength(0); i++) {
            yield return array[i, row];
        }
    }

    public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column) {
        for (int i = 0; i < array.GetLength(1); i++) {
            yield return array[column, i];
        }
    }

    public static IEnumerable<(int x, int y)> GetNeighbourCoords<T>(this T[,] source, int x, int y, bool includeDiagonal = true) {
        int width = source.GetLength(0);
        int height = source.GetLength(1);

        if (x > 0) {
            yield return (x - 1, y);

            if (includeDiagonal) {
                if (y > 0)
                    yield return (x - 1, y - 1);
                if (y < height - 1)
                    yield return (x - 1, y + 1);
            }
        }

        if (x < width - 1) {
            yield return (x + 1, y);

            if (includeDiagonal) {
                if (y > 0)
                    yield return (x + 1, y - 1);
                if (y < height - 1)
                    yield return (x + 1, y + 1);
            }
        }

        if (y > 0)
            yield return (x, y - 1);
        if (y < height - 1)
            yield return (x, y + 1);
    }

    public static IEnumerable<T> GetNeighbours<T>(this T[,] source, int x, int y, bool includeDiagonal = true) {
        foreach (var coord in source.GetNeighbourCoords(x, y, includeDiagonal)) {
            yield return source[coord.x, coord.y];
        }
    }

    public static T Get<T>(this T[,] source, (int, int) index) => source[index.Item1, index.Item2];

    public static int Count<T>(this T[,] source, Func<T, bool> predicate) {
        int count = 0;
        for (int i = 0; i < source.GetLength(0); i++) {
            for (int j = 0; j < source.GetLength(1); j++) {
                if (predicate(source[i, j]))
                    count++;
            }
        }

        return count;
    }

    public static int Sum(this int[,] source) {
        int count = 0;
        for (int i = 0; i < source.GetLength(0); i++) {
            for (int j = 0; j < source.GetLength(1); j++) {
                count += source[i, j];
            }
        }

        return count;
    }
}
