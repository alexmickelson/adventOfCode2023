using FluentAssertions;

namespace Test;

public class Tests
{
    [Test]
    public void CanGetNeigbors()
    {
        var input = Grid.ParsePoints([
            "-L|F7",
            "7S-7|",
            "L|7||",
            "-L-J|",
            "L|-JF",
        ]);
        var expectedNeighbors = new (int Row, int Col)[] {
            (1, 2),
            (2, 1),
        };

        var actualNeighbors = Grid.GetNeighbors(input, (1, 1));
        actualNeighbors.Should().BeEquivalentTo(expectedNeighbors);
    }
    [Test]
    public void CanGetNeigborsConsideringPoint()
    {
        var input = Grid.ParsePoints([
            "||L|.",
            ".L-J.",
        ]);
        var expectedNeighbors = new (int Row, int Col)[] {
            (1, 1),
        };

        var actualNeighbors = Grid.GetNeighbors(input, (0, 1));
        actualNeighbors.Should().BeEquivalentTo(expectedNeighbors);
    }
    [Test]
    public void CanGetNeigborsConsideringPoint2()
    {
        var input = Grid.ParsePoints([
            "SJLL7",
            "|F--J",
            "LJ.LJ",
        ]);

        var expectedNeighbors = new (int Row, int Col)[] {
            (1, 3),
            (0, 4),
        };

        var actualNeighbors = Grid.GetNeighbors(input, (1, 4));
        actualNeighbors.Should().BeEquivalentTo(expectedNeighbors);
    }

    [Test]
    public void CanGetLongestPath()
    {
        
        var input = Grid.ParsePoints([
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            ".....",
        ]);

        var longestPath = Grid.LongestPointDistance(input);
        longestPath.Should().Be(4);
    }
    [Test]
    public void CanGetLongestPath2()
    {
        
        var input = Grid.ParsePoints([
            "..F7.",
            ".FJ|.",
            "SJ.L7",
            "|F--J",
            "LJ...",
        ]);

        var longestPath = Grid.LongestPointDistance(input);
        longestPath.Should().Be(8);
    }
    [Test]
    public void CanGetLongestPath3()
    {
        
        var input = Grid.ParsePoints([
            "7-F7-",
            ".FJ|7",
            "SJLL7",
            "|F--J",
            "LJ.LJ",
        ]);

        var longestPath = Grid.LongestPointDistance(input);
        longestPath.Should().Be(8);
    }
}