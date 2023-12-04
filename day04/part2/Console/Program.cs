
// var lines = File.ReadAllLines("testInput.txt");
var lines = File.ReadAllLines("realInput.txt");

var cardCount = ScratchCards.CalculateEndCardNumber(lines);
Console.WriteLine(cardCount);