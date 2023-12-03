
// var input = File.ReadAllText("testInput.txt");
var input = File.ReadAllText("realInput.txt");

var numbers = Schematics.GetPartNumbers(input);

Console.WriteLine(numbers.Sum());