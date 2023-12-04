
// var lines = File.ReadAllLines("testInput.txt");
var lines = File.ReadAllLines("realInput.txt");

var points = lines.Select(l => ScratchCards.GetCardWorth(l));

Console.WriteLine(points.Sum());