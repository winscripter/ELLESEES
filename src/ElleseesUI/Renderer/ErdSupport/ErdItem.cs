namespace Renderer.ErdSupport;

/// <summary>
/// A single ERD row with columns.
/// </summary>
/// <param name="Name">Name of the ERD row.</param>
/// <param name="Pairs">Columns of this row.</param>
internal record ErdItem(string Name, ErdPair[] Pairs);

/// <summary>
/// Extensions for <see cref="ErdItem" />.
/// </summary>
internal static class ErdItemExtensions
{
    /// <summary>
    /// Searches the column by its name.
    /// </summary>
    /// <param name="item">Input ERD row.</param>
    /// <param name="key">Name of the column.</param>
    /// <returns>ERD column with a matching name.</returns>
    /// <exception cref="InvalidOperationException">Thrown when ERD row has no column with name <paramref name="key" />.</exception>
    public static ErdPair SearchKey(this ErdItem item, string key)
    {
        var pair = item.Pairs.Where(p => p.Key == key);

        if (pair.Any())
        {
            return pair.First();
        }
        else
        {
            throw new InvalidOperationException($"ERD item has no pair with key name {key}");
        }
    }

    /// <summary>
    /// Searches an ERD row with a matching name.
    /// </summary>
    /// <param name="items">List of ERD rows.</param>
    /// <param name="name">Name of the first ERD row to search for.</param>
    /// <returns>First row with a matching name.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no ERD row was found with a matching name.</exception>
    public static ErdItem SearchItemByName(this ErdItem[] items, string name)
    {
        var item = items.Where(i => i.Name == name);

        if (item.Any())
        {
            return item.First();
        }
        else
        {
            throw new InvalidOperationException($"No ERD item was found with name {name}");
        }
    }

    /// <summary>
    /// Returns the value of the ERD column by its name.
    /// </summary>
    /// <param name="item">An ERD row.</param>
    /// <param name="key">A column to search for.</param>
    /// <returns>Value of first ERD column by given name that matches.</returns>
    public static string ValueOf(this ErdItem item, string key) => item.SearchKey(key).Value;
}
