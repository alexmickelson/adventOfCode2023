
using System.Text.Json;

// var input = File.ReadAllText("./testInput.txt");
var input = File.ReadAllText("./realInput.txt");

var seeds = input.Split(Environment.NewLine)[0].Split(' ')[1..].Select(s => long.Parse(s)).ToArray();

var rawMapStrings = string.Join(Environment.NewLine, input.Split(Environment.NewLine)[2..]).Split(Environment.NewLine + Environment.NewLine);

var maps = rawMapStrings.Select(s => new Map(s.Split(Environment.NewLine)));


Console.WriteLine(JsonSerializer.Serialize(maps));


var seedLocations = seeds
  .Select(s => Map.GetLastValue(s, "seed", maps));

  Console.WriteLine(seedLocations.Min());


