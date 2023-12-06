using System.Runtime.InteropServices;
using System.Text.Json;

var input = File.ReadAllLines("realInput.txt");
// var input = File.ReadAllLines("testInput.txt");
// string[] input = [
//   "Time:      7  15   30",
//   "Distance:  9  40  200",
// ];

var raceTimes = input[0].Split().Where(s => s != string.Empty).ToList()[1..].Select(s => int.Parse(s)).ToArray();
var raceDistances = input[1].Split().Where(s => s != string.Empty).ToList()[1..].Select(s => int.Parse(s)).ToArray();

Console.WriteLine(JsonSerializer.Serialize(raceTimes));
Console.WriteLine(JsonSerializer.Serialize(raceDistances));

var waysToWinPerRace = raceTimes.Select((t, i) => {
  var count = 0;
  for(int speed = 1; speed < t; speed++)
  {
    var timeToTravel = t - speed;
    if((speed * timeToTravel) > raceDistances[i])
      count++;
  }
  return count;
});

Console.WriteLine(JsonSerializer.Serialize(waysToWinPerRace));

Console.WriteLine(waysToWinPerRace.Aggregate((a, b) => a * b));