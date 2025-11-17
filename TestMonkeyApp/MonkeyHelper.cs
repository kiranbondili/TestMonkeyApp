using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// Provides helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new();

    /// <summary>
    /// Gets the list of all monkeys.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// Gets a monkey by its name.
    /// </summary>
    /// <param name="name">The name of the monkey.</param>
    /// <returns>The monkey if found; otherwise, null.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey from the list.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys.Count == 0) return null;
        var random = new Random();
        int index = random.Next(monkeys.Count);
        return monkeys[index];
    }

    /// <summary>
    /// Loads monkey data asynchronously from the monkeymcp server.
    /// </summary>
    public static async Task LoadMonkeysAsync(Func<Task<List<Monkey>>> fetchMonkeys)
    {
        try
        {
            var result = await fetchMonkeys();
            monkeys = result ?? new List<Monkey>();
        }
        catch (Exception ex)
        {
            // Handle exceptions as needed
            Console.Error.WriteLine($"Error loading monkeys: {ex.Message}");
            monkeys = new List<Monkey>();
        }
    }
}
