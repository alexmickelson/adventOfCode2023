using FluentAssertions;

namespace Test;

public class Tests
{

  [Test]
  public void Test1()
  {
    var input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
    var expected = new int[]{
            467,
            35,
            633,
            617,
            592,
            755,
            664,
            598
        };
    var actual = Schematics.GetPartNumbers(input);
    actual.Should().NotContain(114);
    actual.Should().NotContain(58);

    actual.Should().BeEquivalentTo(expected);
  }

  [Test]
  public void canExtractNumbersFromString()
  {
    var input = "467$..&114..";
    var actual = Schematics.GetNumberRangesFromLine(input);

    actual.Should().BeEquivalentTo([(0, 2), (7, 9)]);
  }

  [Test]
  public void canExtractNumbersFromString2()
  {
    var input = "467$..&114";
    var actual = Schematics.GetNumberRangesFromLine(input);

    actual.Should().BeEquivalentTo([(0, 2), (7, 9)]);
  }
  [Test]
  public void TestPartNumber()
  {
    string[] input = [
        "467..114..",
        "...*......"
    ];

    var numberIndex = (0, 2, 0);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, input);

    isPartNumber.Should().BeTrue();
  }
  [Test]
  public void TestPartNumber2()
  {
    string[] input = [
        "467..114..",
        "...*......"
    ];

    var numberIndex = (5, 7, 0);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, input);

    isPartNumber.Should().BeFalse();
  }
  [Test]
  public void TestPartNumber3()
  {
    string[] input = [
        "467..114",
        "...*...."
    ];

    var numberIndex = (5, 7, 0);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, input);

    isPartNumber.Should().BeFalse();
  }
  [Test]
  public void TestPartNumber4()
  {
    string[] input = [
        "...*..+.",
        "467..114",
    ];

    var numberIndex = (5, 7, 1);

    var isPartNumber = Schematics.IsPartNumber(numberIndex, input);

    isPartNumber.Should().BeTrue();
  }

  [Test]
  public void CanParseNumbers()
  {

    string[] rows = [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598..",
    ];

    var parsedInt = Schematics.ReadInt((0, 2, 0), rows);
    parsedInt.Should().Be(467);
  }

  [Test]
  public void CanParseNumbers2()
  {

    string[] rows = [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598..",
    ];

    var parsedInt = Schematics.ReadInt((6, 8, 7), rows);
    parsedInt.Should().Be(755);
  }
}