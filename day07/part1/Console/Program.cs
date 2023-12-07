
using System.Text.Json;

// var input = File.ReadAllLines("testInput.txt");
var input = File.ReadAllLines("realInput.txt");

var hands = input.Select(i =>
{
  return new { cards = i.Split()[0], bid = int.Parse(i.Split()[1]) };
}).ToList();



hands.Sort((a, b) =>
{
  return Poker.CompareHand(a.cards, b.cards);
});
hands.Reverse();

var winnings = hands.Select((hand, i) => (hands.Count - i) * hand.bid  );

Console.WriteLine(JsonSerializer.Serialize(hands));

Console.WriteLine(winnings.Sum());