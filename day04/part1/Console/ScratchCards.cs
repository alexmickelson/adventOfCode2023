
using System.Reflection.Metadata.Ecma335;

public class ScratchCards
{
  public static int GetCardWorth(string input)
  {
    var myNumbers = GetMyWinningNumbers(input);

    if (myNumbers.Count() == 0)
      return 0;
    
    return(int) Math.Pow(2, myNumbers.Count() - 1);
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