using System.Text.Json;

var input = File.ReadAllLines("realInput.txt");
// var input = File.ReadAllLines("testInput.txt");
// string[] input = [
//   "Time:      7  15   30",
//   "Distance:  9  40  200",
// ];

var time = input[0].Replace(" ", "").Split(':')[1..].Select(s => long.Parse(s)).First();
var distance = input[1].Replace(" ", "").Split(':')[1..].Select(s => long.Parse(s)).First();

Console.WriteLine(JsonSerializer.Serialize(time));
Console.WriteLine(JsonSerializer.Serialize(distance));


var count = 0;
for (long speed = 1; speed < time; speed++)
{
  var timeToTravel = time - speed;
  if ((speed * timeToTravel) > distance)
    count++;
}


Console.WriteLine(count);
// Console.WriteLine(JsonSerializer.Serialize(waysToWinPerRace));

// Console.WriteLine(waysToWinPerRace.Aggregate((a, b) => a * b));