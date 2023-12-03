using FluentAssertions;

public class GearRatioTests
{
  [Test]
  public void CanGetStarIndex()
  {
    string[] lines = [
      "467..114..",
      "...*......",
      "..35..633.",
    ];

    var starIndexes = Schematics.GetStarIndexes(lines);
    starIndexes.Should().BeEquivalentTo([(1, 3)]);
  }
  [Test]
  public void CanGetStarIndex2()
  {
    string[] lines = [
      "467..114..",
      "...*......",
      "..35..633*",
    ];

    var starIndexes = Schematics.GetStarIndexes(lines);
    starIndexes.Should().BeEquivalentTo([(1, 3), (2, 9)]);
  }

  [Test]
  public void CanCheckIfStarIsGearRatio()
  {
    string[] lines = [
      "467..114..",
      "...*......",
      "..35..633*",
    ];

    var starIndex = (2, 9);

    var numberRanges = Schematics.GetNumberRangesFromStrings(lines);
    var isGearRatio = Schematics.StarIsGearRatio(starIndex, lines, numberRanges);
    isGearRatio.Should().BeFalse();
  }

  [Test]
  public void CanCheckIfStarIsGearRatio2()
  {
    string[] lines = [
      "467..114..",
      "...*......",
      "..35..633*",
    ];

    var starIndex = (1, 3);

    var numberRanges = Schematics.GetNumberRangesFromStrings(lines);
    var isGearRatio = Schematics.StarIsGearRatio(starIndex, lines, numberRanges);
    isGearRatio.Should().BeTrue();
  }

  [Test]
  public void CanGetGearRatioCenters()
  {
    string[] lines = [
      "467..114..",
      "...*......",
      "..35..633*",
    ];

    var indexesOfGearRatios = Schematics.GetGearRatioCenters(lines);
    indexesOfGearRatios.Should().BeEquivalentTo([(1, 3)]);
  }

  [Test]
  public void CanGetGearRatio()
  {
    string[] lines = [
      "467..114..",
      "...*......",
      "..35..633*",
    ];

    var starIndex = (1, 3);

    var numberRanges = Schematics.GetNumberRangesFromStrings(lines);
    var gearRatio = Schematics.GetGearRatio(starIndex, lines, numberRanges);
    gearRatio.Should().Be(467 * 35);
  }
}