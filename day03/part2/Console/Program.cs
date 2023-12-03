
using System.Text.Json;

// var input = File.ReadAllText("testInput.txt");
var input = File.ReadAllText("realInput.txt");


var lines = input.Split(Environment.NewLine);
var numberRanges = Schematics.GetNumberRangesFromStrings(lines);



var indexesOfGearRatios = Schematics.GetGearRatioCenters(lines);
var gearRatios = indexesOfGearRatios
  .Select(starIndex => Schematics.GetGearRatio(starIndex, lines, numberRanges))
  .ToArray();


Console.WriteLine(JsonSerializer.Serialize(gearRatios));
Console.WriteLine(gearRatios.Sum());