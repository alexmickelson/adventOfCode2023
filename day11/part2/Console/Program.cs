

// var input = File.ReadAllLines("testInput.txt");
var input = File.ReadAllLines("realInput.txt");

// var expandedGalaxy = Galaxy.Expand(input);

var galaxyPairs = Galaxy.GetPairs(input);

var paths = galaxyPairs.Select(p => Galaxy.ShortestPath(p));

System.Console.WriteLine(paths.Sum());