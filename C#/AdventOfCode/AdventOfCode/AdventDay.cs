using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace AdventOfCode;

/// <summary>
/// The base class of advent of code solutions.
/// <para>Put the code to solve the individual parts in <see cref="SolvePart1(out T)"/> and <see cref="SolvePart2(T)"/>.</para>
/// <para>Allows for keeping state between solves.</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AdventDay<T> : AdventDay {
    private T state = default!;

    protected AdventDay(int day, int year, string title, bool useTest = false) : base(day, year, title, useTest) { }

    /// <inheritdoc/>
    protected override sealed object SolvePart1() {
        return SolvePart1(out state);
    }

    /// <inheritdoc/>
    protected override sealed object SolvePart2() {
        return SolvePart2(state);
    }

    /// <summary>
    /// The solution to the first problem of the day.
    /// </summary>
    /// <param name="state">The state to pass to <see cref="SolvePart2(T)"/></param>
    /// <returns>The result of the problem.</returns>
    protected abstract object SolvePart1(out T state);

    /// <summary>
    /// The solution to the second problem of the day.
    /// </summary>
    /// <param name="state">The state passed back out from <see cref="SolvePart1(out T)"/></param>
    /// <returns>The result of the problem.</returns>
    protected abstract object SolvePart2(T state);
}

/// <summary>
/// The base class of advent of code solutions.
/// <para>Put the code to solve the individual parts in <see cref="SolvePart1"/> and <see cref="SolvePart2"/>.</para>
/// <para>To keep state between solves, the use of <see cref="AdventDay{T}"/> can be used instead.</para>
/// </summary>
public abstract class AdventDay {
    private const string BASE_URL = "https://adventofcode.com";

    /// <summary>
    /// The day of this problem.
    /// </summary>
    public int Day { get; }
    /// <summary>
    /// The year this problem comes from.
    /// </summary>
    public int Year { get; }
    /// <summary>
    /// The title of the problem.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Whether we are currently using test data or the actual problem data.
    /// </summary>
    protected bool UseTest { get; private set; }

    /// <summary>
    /// The input to the problem.
    /// </summary>
    protected string Input => UseTest ? testInput! : input;
    /// <summary>
    /// The input to the problem, seperated by lines.
    /// </summary>
    protected string[] Lines => UseTest ? testLines! : lines;

    private readonly string input;
    private readonly string[] lines;

    private readonly string? testInput;
    private readonly string[]? testLines;

    private TimeSpan timeToCalculate;

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

    /// <summary>
    /// Solves all the <see cref="AdventDay"/> solutions found in the passed assembly.
    /// <para>Keep in mind that only 25 solutions can be used, 1 for each day. Not passing the day parameter in the constructor, or using a value not between 1 and 25 is not supported.</para>
    /// </summary>
    /// <param name="assembly">The assembly to search for solutions in.</param>
    /// <param name="onlyRunLast">If <see langword="true"/>, only runs the last solution it found (so the solution for the latest day). If <see langword="false"/>, runs all found solutions.</param>
    public static void SolveAll(Assembly assembly, bool onlyRunLast = true) {
        AdventDay?[] instances = new AdventDay?[25];
        foreach (var type in assembly.GetTypes()) {
            if (typeof(AdventDay).IsAssignableFrom(type) && !type.IsGenericType) {
                if (Activator.CreateInstance(type) is not AdventDay instance)
                    continue;

                instances[instance.Day - 1] = instance;
            }
        }

        Console.WriteLine("Solving Advent of code:");

        TimeSpan totalTicks = TimeSpan.Zero;
        if (onlyRunLast) {
            var instance = instances.LastOrDefault(instance => instance != null);

            instance?.Solve();
            totalTicks += instance?.timeToCalculate ?? TimeSpan.Zero;
        } else {
            for (int i = 0; i < instances.Length; i++) {
                if (instances[i] == null)
                    continue;

                instances[i]!.Solve();
                totalTicks += instances[i]!.timeToCalculate;
            }
        }

        var timeToCalculate = totalTicks.TotalMilliseconds;
        Console.WriteLine($"Total time spent: {timeToCalculate:F3} ms");
    }

    /// <summary>
    /// Solves the problem using the solutions created.
    /// </summary>
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
        timeToCalculate = oneTicks + twoTicks;
    }

    /// <summary>
    /// The solution to the first problem of the day.
    /// </summary>
    /// <returns>The result of the problem.</returns>
    protected abstract object SolvePart1();

    /// <summary>
    /// The solution to the second problem of the day.
    /// </summary>
    /// <returns>The result of the problem.</returns>
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

    private static void SolvePart(Func<object> solveFunc, string header, out TimeSpan timeToCalculate) {
        var stopwatch = Stopwatch.StartNew();

        object? result = null;

        try {
            result = solveFunc();
        } catch (NotImplementedException) { } catch (Exception) {
            throw;
        }

        stopwatch.Stop();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(header);
        Console.Write("Result: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);
        Console.ForegroundColor = ConsoleColor.White;
        timeToCalculate = stopwatch.Elapsed;
        var timeToPrint = timeToCalculate.TotalMilliseconds;
        string timeSuffix = "ms";
        if (timeToPrint < 0.01) {
            timeToPrint *= 1000;
            timeSuffix = "μs";
        }
        Console.WriteLine($"Calculated in: {timeToPrint:F3} {timeSuffix}");
    }
}
