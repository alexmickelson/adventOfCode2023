

// var input = File.ReadAllLines("testInput.txt");
var input = File.ReadAllLines("realInput.txt");

var expandedGalaxy = Galaxy.Expand(input);

var galaxyPairs = Galaxy.GetPairs(expandedGalaxy);

var paths = galaxyPairs.Select(p => Galaxy.ShortestPath(expandedGalaxy, p));

System.Console.WriteLine(paths.Sum());