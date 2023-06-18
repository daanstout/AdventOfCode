namespace AdventOfCode;

/// <summary>
/// A class containing extensions to <see cref="char"/>s.
/// </summary>
public static class CharExtensions {
    /// <summary>
    /// Parses a <see cref="char"/> to a <see cref="int"/>.
    /// <para>Note that this parses the literal character value as an int, and not its binary value, so '9' is parsed to 9.</para>
    /// </summary>
    /// <param name="c">The character to parse.</param>
    /// <returns>An int from the character value.</returns>
    public static int ToInt32(this char c) => c.ToString().ToInt32();
}
