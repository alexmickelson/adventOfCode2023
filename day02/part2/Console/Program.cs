
using System.Globalization;
using System.Text.Json;

// var input = File.ReadAllText("testInput.txt");
var input = File.ReadAllText("realInput.txt");

var games = input.Split(Environment.NewLine).Select(s => new Game(s)).ToArray();


var colors = new string[]
{
  "red", "green", "blue"
};
var actualCubes = new Dictionary<string, int>()
{
  ["red"] = 12,
  ["green"] = 13,
  ["blue"] = 14,
};

var minimumCubes = games
  .Select(g => 
    new Dictionary<string, int>() 
    {
      ["red"] = g.Rounds.Max(r => r.ContainsKey("red") ? r["red"] : 0),
      ["green"] = g.Rounds.Max(r => r.ContainsKey("green") ? r["green"] : 0),
      ["blue"] = g.Rounds.Max(r => r.ContainsKey("blue") ? r["blue"] : 0),
    }
  ).ToList();

// minimumCubes.ForEach(m => {
//   Console.WriteLine(JsonSerializer.Serialize(m));
// });

var gamePowers = minimumCubes.Select(m => m["green"] * m["red"] * m["blue"]).ToList();
gamePowers.ForEach(Console.WriteLine);

Console.WriteLine(gamePowers.Sum());
// Console.WriteLine(JsonSerializer.Serialize(possibleGames));

// Console.WriteLine(possibleGames.Count);
// Console.WriteLine(possibleGames.Sum(g => g.Id));
