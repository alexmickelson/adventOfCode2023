
// var input = File.ReadAllLines("testInput.txt");
var input = File.ReadAllLines("realInput.txt");

var result = input.Select(r => HotSprings.GetArrangementCount(r)).Sum();

System.Console.WriteLine(result);