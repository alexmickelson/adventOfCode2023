
using System.Collections.Concurrent;
using System.Text.Json;

// var input = File.ReadAllText("./testInput.txt");
var input = File.ReadAllText("./realInput.txt");

var rawMapStrings = string.Join(Environment.NewLine, input.Split(Environment.NewLine)[2..]).Split(Environment.NewLine + Environment.NewLine);
var maps = rawMapStrings.Select(s => new Map(s.Split(Environment.NewLine)));
var fastMaps = maps.ToDictionary(m => m.Source, m => m);



var seedNumbers = input.Split(Environment.NewLine)[0].Split(' ')[1..].Select(s => long.Parse(s));
var groupedNumbers = seedNumbers
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / 2)
        .Select(x => x.Select(v => v.Value).ToList());


// long lowestLocation = 999999999999999999;
// long counter = 0;
// long expectedItterations = 1807562333;
// foreach (var nums in groupedNumbers)
// {
//   long lowestLocation = 999999999999999999;
//   for (long seedNumber = nums[0]; seedNumber < nums[0] + nums[1]; seedNumber++)
//   {
//     var location = Map.GetLastValue(seedNumber, "seed", maps);
//     if (location < lowestLocation)
//       lowestLocation = location;
//     counter++;
//   }
// }

// double progressPercentage = (double)counter / expectedItterations * 100;
// Console.WriteLine($"Progress: {progressPercentage:0.00}%");
// Console.WriteLine(counter);
// Console.WriteLine(lowestLocation);




ConcurrentBag<long> lowestLocations = new ConcurrentBag<long>();

Console.WriteLine(groupedNumbers.Count());

IEnumerable<List<long>> splitAgainNumbers = groupedNumbers.SelectMany(numbers =>
{
  long start = numbers[0];
  long firstLength = numbers[1] / 2;
  long secondstart = start + firstLength;
  long secondLength = numbers[1] - firstLength;
  return new List<List<long>>() { new List<long>(){start, firstLength}, new List<long>(){secondstart, secondLength}};
});

// Console.WriteLine(JsonSerializer.Serialize(groupedNumbers));
// Console.WriteLine(JsonSerializer.Serialize(splitAgainNumbers));


Parallel.ForEach(splitAgainNumbers, nums =>
{
  long localLowestLocation = 999999999999999999;

  for (long seedNumber = nums[0]; seedNumber < nums[0] + nums[1]; seedNumber++)
  {
    var location = Map.GetLastValue(seedNumber, "seed", fastMaps);
    if (location < localLowestLocation)
      localLowestLocation = location;
  }

  Console.WriteLine("finished one batch");
  Console.WriteLine(localLowestLocation);
  lowestLocations.Add(localLowestLocation);
});

Console.WriteLine(lowestLocations.Min());


// not 3117212723
// not 1765298118
// not 210388587