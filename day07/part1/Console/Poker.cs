
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

public class Poker
{
  public static int CompareHand(string firstHand, string secondHand)
  {

    var firstHandCharacterCount = firstHand.GroupBy(c => c).Select(c => (character: c, count: c.Count()));
    var secondHandCharacterCount = secondHand.GroupBy(c => c).Select(c => (character: c, count: c.Count()));

    var firstHandOrderedCharacters = firstHandCharacterCount.OrderBy((item) => item.count).Reverse().ToArray();
    var secondHandOrderedCharacters = secondHandCharacterCount.OrderBy((item) => item.count).Reverse().ToArray();


    var firstHandLargestCount = firstHandOrderedCharacters[0].count;
    var secondHandLargestCount = secondHandOrderedCharacters[0].count;

    // greater than 3
    if (
      firstHandLargestCount == secondHandLargestCount
      && firstHandLargestCount > 3
      && secondHandLargestCount > 3
    )
      return CompareSameOrder(firstHand, secondHand);
    if (firstHandLargestCount == 5)
      return 1;
    if (secondHandLargestCount == 5)
      return -1;
    if (firstHandLargestCount == 4)
      return 1;
    if (secondHandLargestCount == 4)
      return -1;

    // three of a kind and full house
    if (firstHandLargestCount == 3 && secondHandLargestCount == 3)
    {
      var firstHandSecondCount = firstHandOrderedCharacters[1].count;
      var secondHandSecondCount = secondHandOrderedCharacters[1].count;
      if (firstHandSecondCount == secondHandSecondCount)
        return CompareSameOrder(firstHand, secondHand);

      return firstHandSecondCount - secondHandSecondCount;
    }



    // two pair beats one pair
    if (firstHandLargestCount == 2 && secondHandLargestCount == 2)
    {
      var firstHandSecondCount = firstHandOrderedCharacters[1].count;
      var secondHandSecondCount = secondHandOrderedCharacters[1].count;
      if (firstHandSecondCount == secondHandSecondCount)
        return CompareSameOrder(firstHand, secondHand);
      return firstHandSecondCount - secondHandSecondCount;
    }

    if(firstHandLargestCount == 1 && secondHandLargestCount == 1)
      return CompareSameOrder(firstHand, secondHand);


    if (firstHandLargestCount > secondHandLargestCount)
      return 1;
    else
      return -1;
  }

  private static int CompareSameOrder(string firstHand, string secondHand)
  {
    for (int i = 0; i < firstHand.Count(); i++)
    {
      if (firstHand[i] != secondHand[i])
      {
        return CardValue(firstHand[i]) - CardValue(secondHand[i]);
      }
    }
    return 1;
  }

  private static int CardValue(char card) =>
    card switch
    {
      'A' => 12,
      'K' => 11,
      'Q' => 10,
      'J' => 9,
      'T' => 8,
      '9' => 7,
      '8' => 6,
      '7' => 5,
      '6' => 4,
      '5' => 3,
      '4' => 2,
      '3' => 1,
      '2' => 0,
    };
}