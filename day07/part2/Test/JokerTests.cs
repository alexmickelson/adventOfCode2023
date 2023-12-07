using FluentAssertions;

public class JokerTests
{
  [Test]
  public void TestJokerCountsAsBest()
  {
    Poker.CompareHand("AAAJJ", "AA8AA").Should().Be(1);
  }
  [Test]
  public void TestJokerCountsAsBest2()
  {
    Poker.CompareHand("AA8AA", "AAAJJ").Should().BeLessThan(0);
  }

  [Test]
  public void Jokers_SuckAsTieBreakers()
  {
    Poker.CompareHand("22233", "22J33").Should().BeGreaterThan(0);
  }
  [Test]
  public void Jokers_SuckAsTieBreakers2()
  {
    Poker.CompareHand("22J33", "22233").Should().BeLessThan(0);
  }
  [Test]
  public void Jokers_SuckAsTieBreakers3()
  {
    Poker.CompareHand("22J22", "22222").Should().BeLessThan(0);
  }
  [Test]
  public void JokersAreMostCommon()
  {
    Poker.CompareHand("JJJ22", "22223").Should().BeGreaterThan(0);
  }
}