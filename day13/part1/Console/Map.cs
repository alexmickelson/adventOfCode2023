
using System.Text.Json;

public class Map
{

    public static bool IsHorizontalMirror(string[] rows, int i)
    {

        if (i >= rows.Length - 1)
            return false;
        var mirroredIndex = i + 1;

        while (i >= 0)
        {

            if (i < 0 || mirroredIndex >= rows.Length)
            {
                return true;
            }
            // Console.WriteLine(JsonSerializer.Serialize(rows));
            // System.Console.WriteLine(i);
            // System.Console.WriteLine(mirroredIndex);

            if (rows[i] != rows[mirroredIndex])
            {
                return false;
            }
            i--;
            mirroredIndex++;
        }
        return true;
    }

    public static bool IsVerticalMirror(string[] rows, int i)
    {

        if (i >= rows[0].Length - 1)
            return false;


        var mirroredIndex = i + 1;
        while (i >= 0)
        {

            if (i < 0 || mirroredIndex >= rows[0].Length)
            {
                return true;
            }
            var currentColumn = rows.Select(r => r[i]);
            var mirroredColumn = rows.Select(r => r[mirroredIndex]);
            if (!currentColumn.SequenceEqual(mirroredColumn))
            {
                return false;
            }
            i--;
            mirroredIndex++;
        }
        return true;
    }
    public static IEnumerable<int> GetHorizontalMirrors(string[] maps)
    {
        return maps.SelectMany((m) =>
        {
            return GetHorizontalMirrors(m);
        });
    }

    public static IEnumerable<int> GetHorizontalMirrors(string m)
    {
        var rows = m.Split(Environment.NewLine);
        var output = new List<int>();
        for (var i = 0; i < rows.Length; i++)
        {
            if (Map.IsHorizontalMirror(rows, i))
                output.Add(i);
        }
        return output;
    }

    public static IEnumerable<int> GetVerticalMirrors(string[] maps)
    {
        return maps.SelectMany(GetVerticalMirrors);
    }

    public static IEnumerable<int> GetVerticalMirrors(string m)
    {
        var rows = m.Split(Environment.NewLine);
        var output = new List<int>();
        for (var i = 0; i < rows[0].Length; i++)
        {
            if (Map.IsVerticalMirror(rows, i))
                output.Add(i);
        }
        return output;
    }
}