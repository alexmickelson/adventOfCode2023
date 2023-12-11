using FluentAssertions;

namespace Test;

public class GalaxyTest
{

    [Test]
    public void CanGetPairs()
    {
        string[] input = [
            "...#......",
            ".......#..",
            "#.........",
            "..........",
            "......#...",
            ".#........",
            ".........#",
            "..........",
            ".......#..",
            "#...#.....",
        ];

        var pairs = Galaxy.GetPairs(input);
        pairs.Count().Should().Be(36);
        pairs.Where(p => p.Count != 2).Should().BeEmpty();
        pairs.Should().OnlyHaveUniqueItems();

        var expectedPair = new HashSet<Point>() {
            new (0, 1_000_003 - 1),
            new (1, 2_000_007 - 2)
        };

        pairs.Should().ContainEquivalentOf(expectedPair);
    }

    [Test]
    public void CanGetShortestPath()
    {

        var galaxies = new HashSet<Point>() { new(6, 1), new(11, 5)};
        var pathLength = Galaxy.ShortestPath(galaxies);

        pathLength.Should().Be(9);

    }
}