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

}