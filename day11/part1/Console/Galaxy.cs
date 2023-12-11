

using System.Linq.Expressions;

public class Galaxy
{
    public static string[] Expand(string[] input)
    {
        var expandedRows = expandRows(input);
        return expandCols(expandedRows);
    }

    private static string[] expandRows(string[] input)
    {
        return input.SelectMany(
            new Func<string, string[]>(row => 
                row.All(r => r == '.')
                    ? [row, row]
                    : [row]
            )
        ).ToArray();
    }
    private static string[] expandCols(string[] input)
    {
        var indexes = new List<int>();
        for(int i = 0; i < input[0].Length; i++)
        {
            if(input.All(row => row[i] == '.'))
                indexes.Add(i);
        }

        return input
            .Select(row => {
                return string.Join(
                    "",
                    row.SelectMany(new Func<char, int, char[]>(
                        (c, i) => 
                            indexes.Contains(i)
                                ? [c, c]
                                : [c] 
                        )
                    )
                );
            })
            .ToArray();
    }

    public static IEnumerable<HashSet<Point>> GetPairs(string[] input)
    {
        var coordinates = input.SelectMany((row, rowIndex) => 
            row.SelectMany((c, colIndex) => c == '#' ? [new Point(rowIndex, colIndex)] : Array.Empty<Point>())
        ).ToArray();
        var coordinatePairs = new HashSet<HashSet<Point>>();

        for(int i = 0; i < coordinates.Count(); i++)
        {
            for (int j = i + 1; j < coordinates.Count(); j++)
            {
                coordinatePairs.Add(
                    new HashSet<Point>() { coordinates[i], coordinates[j] }
                );
            }
        }
        return coordinatePairs;
    }

    public static int ShortestPath(string[] input, HashSet<Point> galaxies)
    {
        var first =  galaxies.First();
        var second =  galaxies.Last();

        return Math.Abs(first.Row - second.Row) + Math.Abs(first.Col - second.Col);
    }
}

public record Point(int Row, int Col);