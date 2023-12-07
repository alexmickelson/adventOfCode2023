
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

public class Poker
{
  public static int CompareHand(string firstHand, string secondHand)
  {

    var firstHandCharacterCount = firstHand.GroupBy(c => c).Select(c => (character: c.First(), count: c.Count()));
    var secondHandCharacterCount = secondHand.GroupBy(c => c).Select(c => (character: c.First(), count: c.Count()));

    var firstHandOrderedCharacters = firstHandCharacterCount.OrderBy((item) => item.count).Reverse().ToArray();
    var secondHandOrderedCharacters = secondHandCharacterCount.OrderBy((item) => item.count).Reverse().ToArray();
    int firstLargest = GetLargest(firstHandOrderedCharacters);
    int secondLargest = GetLargest(secondHandOrderedCharacters);

    if (firstLargest > 3 || secondLargest > 3)
      return CompareLarge(firstHand, secondHand, firstLargest, secondLargest);

    if (firstLargest == 3 && secondLargest == 3)
      return CompareBothThree(firstHand, secondHand, firstHandOrderedCharacters, secondHandOrderedCharacters);

    if (firstLargest == 2 && secondLargest == 2)
      return CompareBothTwo(firstHand, secondHand, firstHandOrderedCharacters, secondHandOrderedCharacters);

    if (firstLargest == 1 && secondLargest == 1)
      return CompareSameOrder(firstHand, secondHand);

    if (firstLargest > secondLargest)
      return 1;
    else
      return -1;
  }

  private static int GetLargest((char character, int count)[] firstHandOrderedCharacters)
  {
    var tempFirstJokers = firstHandOrderedCharacters.Where(item => item.character == 'J');
    var firstJokers = tempFirstJokers.Any() ? tempFirstJokers.First().count : 0;
    var firstLargest = firstJokers == 5
      ? 5
      : firstHandOrderedCharacters.Where(item => item.character != 'J').First().count + firstJokers;
    return firstLargest;
  }

  private static int CompareLarge(string firstHand, string secondHand, int firstLargest, int secondLargest)
  {
    // greater than 3
    if (
      firstLargest == secondLargest
      && firstLargest > 3
      && secondLargest > 3
    )
      return CompareSameOrder(firstHand, secondHand);
    if (firstLargest == 5)
      return 1;
    if (secondLargest == 5)
      return -1;
    if (firstLargest == 4)
      return 1;
    return -1;
  }
  private static int CompareBothTwo(string firstHand, string secondHand, (char character, int count)[] firstHandOrderedCharacters, (char character, int count)[] secondHandOrderedCharacters)
  {
    var firstHandSecondCount = firstHandOrderedCharacters[1].count;
    var secondHandSecondCount = secondHandOrderedCharacters[1].count;
    if (firstHandSecondCount == secondHandSecondCount)
      return CompareSameOrder(firstHand, secondHand);
    return firstHandSecondCount - secondHandSecondCount;
  }

  private static int CompareBothThree(string firstHand, string secondHand, (char character, int count)[] firstHandOrderedCharacters, (char character, int count)[] secondHandOrderedCharacters)
  {
    var firstHandSecondCount = firstHandOrderedCharacters[1].count;
    var secondHandSecondCount = secondHandOrderedCharacters[1].count;
    if (firstHandSecondCount == secondHandSecondCount)
      return CompareSameOrder(firstHand, secondHand);

    return firstHandSecondCount - secondHandSecondCount;
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
      'T' => 9,
      '9' => 8,
      '8' => 7,
      '7' => 6,
      '6' => 5,
      '5' => 4,
      '4' => 3,
      '3' => 2,
      '2' => 1,
      'J' => 0,
    };
}