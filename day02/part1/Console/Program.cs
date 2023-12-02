
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

var possibleGames = games
  .Where(g => {
    return g.Rounds.All(round => 
      colors.All(c => !round.ContainsKey(c) || round[c] <= actualCubes[c] )
    );
  }).ToList();

// Console.WriteLine(JsonSerializer.Serialize(possibleGames));

Console.WriteLine(possibleGames.Count);
Console.WriteLine(possibleGames.Sum(g => g.Id));


public record Game
{
  public int Id { get; set; }
  public Dictionary<string, int>[] Rounds { get; set; }
  public Game(string input)
  {
    Id = int.Parse(input.Split(":")[0].Split(" ")[1]);
    var roundStrings = input.Split(":")[1].Split(";");

    Rounds = roundStrings.Select(
      s =>
        s.Split(",").ToDictionary(
          rawDice => rawDice switch
          {
            string a when a.Contains("blue") => "blue",
            string a when a.Contains("red") => "red",
            string a when a.Contains("green") => "green",
          },
          rawDice => int.Parse(rawDice.Trim().Split(" ")[0]
        )
      )
    ).ToArray();
  }
}