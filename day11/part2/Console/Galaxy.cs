

using System.Linq.Expressions;

public class Galaxy
{
    private const long expansionValue = 1_000_000;
    // private const long expansionValue = 10;

    private static IEnumerable<long> ColsToExpand(IEnumerable<string> input)
    {
        var indexes = new List<long>();
        for(int i = 0; i < input.ElementAt(0).Length; i++)
        {
            if(input.All(row => row[i] == '.'))
                indexes.Add(i);
        }
        return indexes;
    }

    private static IEnumerable<long> RowsToExpand(IEnumerable<string> input)
    {
        var indexes = new List<long>();
        for(int i = 0; i < input.Count(); i++)
        {
            if(input.ElementAt(i).All(c => c == '.'))
                indexes.Add(i);
        }
        return indexes;
    }

    public static IEnumerable<HashSet<Polong>> GetPairs(IEnumerable<string> input)
    {
        var expandedCols = ColsToExpand(input);
        var expandedRows = RowsToExpand(input);
        var coordinates = input.SelectMany((row, rowIndex) => 
            row.SelectMany((c, colIndex) => 
            {
                var adjustedRow = rowIndex + (
                    expandedRows.Where(rIndex => rIndex < rowIndex ).Count() * (expansionValue - 1)
                );
                var adjustedCol = colIndex + (
                    expandedCols.Where(cIndex => cIndex < colIndex ).Count() * (expansionValue - 1)
                );

                return c == '#' 
                    ? [new Polong(adjustedRow, adjustedCol)] 
                    : Array.Empty<Polong>();
            })
        ).ToArray();
        var coordinatePairs = new HashSet<HashSet<Polong>>();

        for(long i = 0; i < coordinates.Count(); i++)
        {
            for (long j = i + 1; j < coordinates.Count(); j++)
            {
                coordinatePairs.Add(
                    new HashSet<Polong>() { coordinates[i], coordinates[j] }
                );
            }
        }
        return coordinatePairs;
    }

    public static long ShortestPath(HashSet<Polong> galaxies)
    {
        var first =  galaxies.First();
        var second =  galaxies.Last();

        return Math.Abs(first.Row - second.Row) + Math.Abs(first.Col - second.Col);
    }
}

public record Polong(long Row, long Col);