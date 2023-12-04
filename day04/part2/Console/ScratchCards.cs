
using System.Data;
using System.Reflection.Metadata.Ecma335;

public class ScratchCards
{
  public static int CalculateEndCardNumber(
    string[] input
  )
  {
    var cardLookup = GetCardLookup(input);
    return cardLookup.Keys.Count() +  CalculateEndCardNumber(cardLookup.Keys.ToArray(), cardLookup);
  }

  public static int CalculateEndCardNumber(
    int[] cardsToProcess,
    Dictionary<int, int[]> cardLookup
  )
  {
    if(cardsToProcess.Length == 0)
      return 0;
    return cardsToProcess
      .Select(c =>
      {
        var winningNumberCount = cardLookup[c].Count();

        var newCards = Enumerable.Range(c+1, winningNumberCount).ToArray();

        return newCards.Count() + CalculateEndCardNumber(newCards, cardLookup);
      })
      .Sum();
  }

  public static Dictionary<int, int[]> GetCardLookup(string[] input)
  {
    return input.ToDictionary(
      l => int.Parse(l.Split(":")[0].Split()[^1]),
      l => GetMyWinningNumbers(l)
    );
  }

  public static int GetCardWorth(string input)
  {
    var myNumbers = GetMyWinningNumbers(input);

    if (myNumbers.Count() == 0)
      return 0;

    return (int)Math.Pow(2, myNumbers.Count() - 1);
  }

  public static int[] GetMyWinningNumbers(string input)
  {
    var rawAllNumbers = input.Split(": ")[1];
    var winningNumbers = rawAllNumbers
      .Split("|")[0]
      .Trim()
      .Split()
      .Where(s => s != string.Empty)
      .Select(n => int.Parse(n))
      .ToArray();
    var myNumbers = rawAllNumbers
      .Split("|")[1]
      .Trim()
      .Split()
      .Where(s => s != string.Empty)
      .Select(n => int.Parse(n))
      .ToArray();



    return myNumbers
      .Where(n => winningNumbers.Any(w => w == n))
      .ToArray();
  }


}