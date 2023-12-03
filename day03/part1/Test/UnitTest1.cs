using FluentAssertions;

namespace Test;

public class Tests
{

  //   [Test]
  //   public void Test1()
  //   {
  //     var input = @"467..114..
  // ...*......
  // ..35..633.
  // ......#...
  // 617*......
  // .....+.58.
  // ..592.....
  // ......755.
  // ...$.*....
  // .664.598..";
  //     var expected = new int[]{
  //         467,
  //         35,
  //         633,
  //         617,
  //         592,
  //         755,
  //         664,
  //         598
  //     };
  //     var actual = Schematics.GetPartNumbers(input);
  //     actual.Should().NotContain(114);
  //     actual.Should().NotContain(58);

  //     actual.Should().BeEquivalentTo(expected);
  //     // actual.Should().Contain(467);
  //     // actual.Should().Contain(35);
  //     // actual.Should().Contain(633);
  //     // actual.Should().Contain(617);
  //     // actual.Should().Contain(592);
  //     // actual.Should().Contain(755);
  //     // actual.Should().Contain(664);
  //     // actual.Should().Contain(598);
  //   }

  [Test]
  public void canExtractNumbersFromString()
  {
    var input = "467$..&114..";
    var actual = Schematics.GetNumberRangesFromString(input);

    actual.Should().BeEquivalentTo([(0, 2), (7, 9)]);
  }

  [Test]
  public void canExtractNumbersFromString2()
  {
    var input = "467$..&114";
    var actual = Schematics.GetNumberRangesFromString(input);

    actual.Should().BeEquivalentTo([(0, 2), (7, 9)]);
  }
  [Test]
  public void TestPartNumber()
  {
    string[] input = [
        "467..114..",
        "...*......"
    ];

    var numberIndex = (0, 2);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, 0, input);

    isPartNumber.Should().BeTrue();
  }
  [Test]
  public void TestPartNumber2()
  {
    string[] input = [
        "467..114..",
        "...*......"
    ];

    var numberIndex = (5, 7);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, 0, input);

    isPartNumber.Should().BeFalse();
  }
  [Test]
  public void TestPartNumber3()
  {
    string[] input = [
        "467..114",
        "...*...."
    ];

    var numberIndex = (5, 7);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, 0, input);

    isPartNumber.Should().BeFalse();
  }
  [Test]
  public void TestPartNumber4()
  {
    string[] input = [
        "...*..+.",
        "467..114",
    ];

    var numberIndex = (5, 7);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, 1, input);

    isPartNumber.Should().BeTrue();
  }
}