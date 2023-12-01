using System.Text.Json;

// var input = File.ReadAllText("testInput.txt");
var input = File.ReadAllText("realInput.txt");

var digitsAsStrings = input
  .Split(Environment.NewLine)
  .Select(l =>
    firstNumber(l) + 
    lastNumber(string.Join("", l.Reverse()))
  );

var sum = digitsAsStrings.Select(s => int.Parse(s)).Sum();

Console.WriteLine(JsonSerializer.Serialize(digitsAsStrings));
Console.WriteLine(sum);



string firstNumber(string input)
{
  var spelledNumbers = new string[]
  {
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine",
  };
  if (char.IsDigit(input.First()))
    return input.First().ToString();
  
  foreach(var spelledNumber in spelledNumbers)
  {
    if(input.StartsWith(spelledNumber))
    {
      return convertToNumber(spelledNumber);
    }
  }
  return firstNumber(input[1..]);
}
string lastNumber(string invertedInput)
{
  var spelledNumbers = new string[]
  {
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine",
  };
  if (char.IsDigit(invertedInput.First()))
    return invertedInput.First().ToString();
  
  foreach(var spelledNumber in spelledNumbers)
  {
    var reversedNumber = string.Join("", spelledNumber.Reverse());
    if(invertedInput.StartsWith(reversedNumber))
    {
      return convertToNumber(spelledNumber);
    }
  }
  return lastNumber(invertedInput[1..]);
}

static string convertToNumber(string spelledNumber)
{
  return spelledNumber switch
  {
    "one" => "1",
    "two" => "2",
    "three" => "3",
    "four" => "4",
    "five" => "5",
    "six" => "6",
    "seven" => "7",
    "eight" => "8",
    "nine" => "9",
    _ => throw new Exception("invalid spelled number " + spelledNumber),
  };
}