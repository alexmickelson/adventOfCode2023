
using System.Text.Json;

public class Map
{

    public static bool IsHorizontalMirror(string[] rows, int i)
    {
        if (i == rows.Length - 1)
            return false;

        var mirroredDistance = rows.Length - i - 1;

        var minimumDistance = mirroredDistance < i ? mirroredDistance : i;


        var endIsCloser = mirroredDistance < i;
        // var firstPart = rows[(i + 1 - minimumDistance)..(i + 1)];
        var firstPart = endIsCloser
            ? rows[(i + 1 - minimumDistance)..(i + 1)]
            : rows[(i - minimumDistance)..(i + 1)];
        
        var endIndex = i + minimumDistance + 2;
        var secondPart = endIndex < rows.Length
            ? rows[(i + 1)..endIndex]
            : rows[(i + 1)..];

        return string.Join("", firstPart) == string.Join("", secondPart.Reverse());


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
    public static IEnumerable<int> GetManyHorizontalMirrors(string[] maps)
    {
        return maps.SelectMany((m) =>
        {
            return GetHorizontalMirrors(m);
        });
    }

    public static IEnumerable<int> GetHorizontalMirrors(string m)
    {
        var rows = m.Split(Environment.NewLine).Select(l => l.Replace("\r", "")).ToArray();
        for (var i = 0; i < rows.Length; i++)
        {
            if (Map.IsHorizontalMirror(rows, i))
                return [i];
        }
        return [];
    }

    public static IEnumerable<int> GetManyVerticalMirrors(string[] maps)
    {
        return maps.SelectMany(GetVerticalMirrors);
    }

    public static IEnumerable<int> GetVerticalMirrors(string m)
    {

        var rows = m.Split(Environment.NewLine).Select(l => l.Replace("\r", "")).ToArray();
        var inverted = rows[0].Select(m => "").ToList();

        for(int i =0; i < rows.Length; i ++)
        {
            for(int j = 0; j < rows[0].Length; j++)
            {
                inverted[j] += rows[i][j];
            }
        }

        var invertedMap = string.Join(Environment.NewLine,  inverted);

        return GetHorizontalMirrors(invertedMap);


        // var rows = m.Split(Environment.NewLine);
        // var output = new List<int>();
        // for (var i = 0; i < rows[0].Length; i++)
        // {
        //     if (Map.IsVerticalMirror(rows, i))
        //         output.Add(i);
        // }
        // return output;
    }
}