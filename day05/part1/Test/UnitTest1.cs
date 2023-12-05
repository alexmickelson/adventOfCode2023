using FluentAssertions;
using Microsoft.VisualBasic;

namespace Test;

public class Tests
{
  [SetUp]
  public void Setup()
  {
  }

  [Test]
  public void CanParseMapName()
  {
    string[] input = [
      "seed-to-soil map:",
      "50 98 2",
      "52 50 48"
    ];
    var map =  new Map(input);
    map.Source.Should().Be("seed");
    map.Dest.Should().Be("soil");
  }

  [Test]
  public void CanParseRanges()
  {
    string[] input = [
      "seed-to-soil map:",
      "50 98 2",
    ];
    var map =  new Map(input);
    map.Ranges.First().Should().Be(new MapRange(98, 50, 2));
  }
  [Test]
  public void CanGetMappedValue()
  {
    string[] input = [
      "seed-to-soil map:",
      "50 98 2",
    ];
    var map =  new Map(input);

    var actualMappedSoil = map.GetCoorespondingValue(99);
    var expectedMappedSoil = 51;

    actualMappedSoil.Should().Be(expectedMappedSoil);
  }
  [Test]
  public void CanGetUnMappedValue()
  {
    string[] input = [
      "seed-to-soil map:",
      "50 98 2",
    ];
    var map =  new Map(input);

    var actualMappedSoil = map.GetCoorespondingValue(10);
    var expectedMappedSoil = 10;

    actualMappedSoil.Should().Be(expectedMappedSoil);
  }
}