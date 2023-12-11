using FluentAssertions;

namespace Test;

public class GalaxyTest
{

    [Test]
    public void TestCanExpandEmptyGalaxy()
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

        string[] expected = [
            "....#........",
            ".........#...",
            "#............",
            ".............",
            ".............",
            "........#....",
            ".#...........",
            "............#",
            ".............",
            ".............",
            ".........#...",
            "#....#.......",
        ];

        Galaxy.Expand(input).Should().BeEquivalentTo(expected);
    }

    [Test]
    public void CanGetPairs()
    {
        
        string[] input = [
            "....#........",
            ".........#...",
            "#............",
            ".............",
            ".............",
            "........#....",
            ".#...........",
            "............#",
            ".............",
            ".............",
            ".........#...",
            "#....#.......",
        ];

        var pairs = Galaxy.GetPairs(input);
        pairs.Count().Should().Be(36);
        pairs.Where(p => p.Count != 2).Should().BeEmpty();
        pairs.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void CanGetShortestPath()
    {
        string[] input = [
            "....#........",
            ".........#...",
            "#............",
            ".............",
            ".............",
            "........#....",
            ".#...........",
            "............#",
            ".............",
            ".............",
            ".........#...",
            "#....#.......",
        ];

        var galaxies = new HashSet<Point>() { new(6, 1), new(11, 5)};
        var pathLength = Galaxy.ShortestPath(input, galaxies);

        pathLength.Should().Be(9);

    }
}