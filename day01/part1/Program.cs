using System.Text.Json;

// var part1Input = @"1abc2
// pqr3stu8vwx
// a1b2c3d4e5f
// treb7uchet";

var part1Input = File.ReadAllText("part1Input.txt");

var digitsAsStrings = part1Input
  .Split(Environment.NewLine)
  .Select(l => 
    l.First(c => char.IsDigit(c)) + "" 
    + l.Last(c => char.IsDigit(c))
  );

var sum = digitsAsStrings.Select(s => int.Parse(s)).Sum();

Console.WriteLine(JsonSerializer.Serialize(digitsAsStrings));
Console.WriteLine(sum);