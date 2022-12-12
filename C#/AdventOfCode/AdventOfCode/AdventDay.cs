using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace AdventOfCode;

public abstract class AdventDay {
    private const string BASE_URL = "https://adventofcode.com";

    public int Day { get; }
    public int Year { get; }
    public string Title { get; }

    public long TicksToCalculate { get; private set; }

    protected string Input => UseTest ? testInput! : input;
    protected string[] Lines => UseTest ? testLines! : lines;

    protected bool UseTest { get; private set; }

    private readonly string input;
    private readonly string[] lines;

    private readonly string? testInput;
    private readonly string[]? testLines;

    protected AdventDay(int day, int year, string title, bool useTest = false) {
        Day = day;
        Year = year;
        Title = title;

        input = GetInput();
        lines = input.Split("\n");

        if (File.Exists($"TestInput\\Day {day}.txt")) {
            testInput = File.ReadAllText($"TestInput\\Day {day}.txt");
            testLines = testInput.Split("\r\n");

            UseTest = useTest;
        }
    }

    public static void SolveAll(Assembly assembly, bool onlyRunLast = true) {
        AdventDay?[] instances = new AdventDay?[25];
        foreach (var type in assembly.GetTypes()) {
            if (typeof(AdventDay).IsAssignableFrom(type)) {
                if (Activator.CreateInstance(type) is not AdventDay instance)
                    continue;

                instances[instance.Day - 1] = instance;
            }
        }

        Console.WriteLine("Solving Advent of code:");

        long totalTicks = 0;
        if (onlyRunLast) {
            var instance = instances.LastOrDefault(instance => instance != null);

            instance?.Solve();
            totalTicks += instance?.TicksToCalculate ?? 0;
        } else {
            for (int i = 0; i < instances.Length; i++) {
                if (instances[i] == null)
                    continue;

                instances[i]!.Solve();
                totalTicks += instances[i]!.TicksToCalculate;
            }
        }

        var timeToCalculate = TimeSpan.FromTicks(totalTicks).TotalMilliseconds;
        Console.WriteLine($"Total time spent: {timeToCalculate:F3} ms");
    }

    public void Solve() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Day {Day}: {Title}");

        if (UseTest) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DEBUG ENABLED");
        }

        SolvePart(SolvePart1, "Part One:", out var oneTicks);
        Console.WriteLine();
        SolvePart(SolvePart2, "Part Two:", out var twoTicks);
        Console.WriteLine();
        TicksToCalculate = oneTicks + twoTicks;
    }

    protected abstract object SolvePart1();

    protected abstract object SolvePart2();

    private string GetInput() {
        string cacheFile = $"Input\\input-{Year}-{Day}";
        if (File.Exists(cacheFile))
            return File.ReadAllText(cacheFile);

        var session = File.ReadAllText("session.txt");

        var uri = new Uri($"{BASE_URL}");

        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{BASE_URL}/{Year}/day/{Day}/input")
        };
        request.Headers.Add("UserAgent", "mailto:daanstoutdev@gmail.com");
        var cookieContainer = new CookieContainer();
        using var handler = new HttpClientHandler {
            CookieContainer = cookieContainer
        };

        using var client = new HttpClient(handler) {
            BaseAddress = uri
        };

        cookieContainer.Add(uri, new Cookie("session", session) { Expires = default });

        using var response = client.SendAsync(request).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode) {
            var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            result = result.Trim();
            Directory.CreateDirectory("Input");
            File.WriteAllText(cacheFile, result);
            return result;
        }

        throw new WebException($"Could not download input file for Year: {Year} - Day: {Day}");
    }

    private static void SolvePart(Func<object> solveFunc, string header, out long ticksToCalculate) {
        var stopwatch = Stopwatch.StartNew();

        var result = solveFunc();

        stopwatch.Stop();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(header);
        Console.Write("Result: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);
        Console.ForegroundColor = ConsoleColor.White;
        ticksToCalculate = stopwatch.ElapsedTicks;
        var timeToCalculate = TimeSpan.FromTicks(stopwatch.ElapsedTicks).TotalMilliseconds;
        string timeSuffix = "ms";
        if (timeToCalculate < 0.01) {
            timeToCalculate *= 1000;
            timeSuffix = "μs";
        }
        Console.WriteLine($"Calculated in: {timeToCalculate:F3} {timeSuffix}");
    }
}
