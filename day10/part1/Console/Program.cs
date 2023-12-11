

using System.Drawing;

// var rawInput = File.ReadAllLines("testInput.txt");
var rawInput = File.ReadAllLines("realInput.txt");

var input = Grid.ParsePoints(rawInput);

var longestPath = Grid.LongestPointDistance(input);

System.Console.WriteLine(longestPath);
