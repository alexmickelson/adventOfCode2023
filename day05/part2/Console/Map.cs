
public class Map
{
  public string Source { get; set; }
  public string Dest { get; set; }

  public MapRange[] Ranges;
  public Map(string[] input)
  {
    Source = input[0].Split(" ")[0].Split('-')[0];
    Dest = input[0].Split(" ")[0].Split('-')[2];

    Ranges = input[1..]
      .Select(line =>
      {
        var destStart = long.Parse(line.Split(" ")[0]);
        var sourceStart = long.Parse(line.Split(" ")[1]);
        var rangeLength = long.Parse(line.Split(" ")[2]);
        return new MapRange(sourceStart, destStart, rangeLength);
      })
      .ToArray();
  }

  public long GetCoorespondingValue(long input)
  {
    var relevantRange = Ranges.FirstOrDefault(r =>
      r.sourceRangeStart <= input && (r.sourceRangeStart + r.rangelength) > input
    );

    if (relevantRange == null)
      return input;

    var diff = input - relevantRange.sourceRangeStart;
    return relevantRange.destRangeStart + diff;

  }

  public static long GetLastValue(long seed, string source, Dictionary<string, Map> maps)
  {
    var relevantMap = maps[source];
    var newSeed = relevantMap.GetCoorespondingValue(seed);
    if (relevantMap.Dest == "location")
      return newSeed;

    return GetLastValue(newSeed, relevantMap.Dest, maps);
  }
}

public record MapRange(long sourceRangeStart, long destRangeStart, long rangelength);