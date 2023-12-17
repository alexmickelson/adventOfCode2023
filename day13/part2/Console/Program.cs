

using System.Text.Json;

var input = File.ReadAllText("testInput.txt");
// var input = File.ReadAllText("realInput.txt");

var maps = input.Split(Environment.NewLine + Environment.NewLine);


Console.WriteLine(JsonSerializer.Serialize(maps));


IEnumerable<int> horizontalMirrorIndex = Map.GetManyHorizontalMirrors(maps);

IEnumerable<int> verticalMirrorIndex = Map.GetManyVerticalMirrors(maps);

var adjustedHorizontal = horizontalMirrorIndex.Select(i => i + 1);
var adjustedVertical = verticalMirrorIndex.Select(i => i + 1);

Console.WriteLine(JsonSerializer.Serialize(adjustedHorizontal));
Console.WriteLine(JsonSerializer.Serialize(adjustedVertical));

Console.WriteLine((100 * adjustedHorizontal.Sum()) +  adjustedVertical.Sum());

