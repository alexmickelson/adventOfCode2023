using FluentAssertions;

namespace Test;

public class Tests
{
  [SetUp]
  public void Setup()
  {
  }

  [Test]
  public void TestWinningNumbers()
  {
    var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

    int[] numbers = ScratchCards.GetMyWinningNumbers(input);
    numbers.Should().BeEquivalentTo([48, 83, 17, 86]);
  }

  [Test]
  public void TestCanGetCardWorth()
  {

    var input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
    int worth = ScratchCards.GetCardWorth(input);
    worth.Should().Be(8);
  }

  [Test]
  public void CanParseWinningNumbersInCards()
  {
    string[] input = ["Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"];
    var expectedCardLookup = new Dictionary<int, int[]>()
    {
      [1] = [48, 83, 17, 86],
    };

    var actualIndex = ScratchCards.GetCardLookup(input);
    actualIndex.Should().BeEquivalentTo(expectedCardLookup);
  }

  [Test]
  public void CanRecursivelyGetscratchcards()
  {
    var input = new string[]
    {
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
    };

    var cardCount = ScratchCards.CalculateEndCardNumber(input);
    cardCount.Should().Be(1);
  }

  [Test]
  public void CanRecursivelyGetscratchcards2()
  {
    var input = new string[]
    {
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
    };

    var cardCount = ScratchCards.CalculateEndCardNumber(input);
    cardCount.Should().Be(2);
  }

  [Test]
  public void CanRecursivelyGetscratchcards3()
  {
    var input = new string[]
    {
        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        // "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
    };

    var cardCount = ScratchCards.CalculateEndCardNumber(input);
    cardCount.Should().Be(3);
  }

  [Test]
  public void CanRecursivelyGetscratchcards4()
  {
    var input = new string[]
    {
        "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
        "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
        "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
        "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
        "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
        "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
    };

    var cardCount = ScratchCards.CalculateEndCardNumber(input);
    cardCount.Should().Be(30);
  }

}