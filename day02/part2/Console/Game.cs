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