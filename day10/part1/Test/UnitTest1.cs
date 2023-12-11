using FluentAssertions;

namespace Test;

public class Tests
{
    [Test]
    public void CanGetNeigbors()
    {
        var input = new string[] {
            "-L|F7",
            "7S-7|",
            "L|7||",
            "-L-J|",
            "L|-JF",
        };
        var expectedNeighbors = new Dictionary<(int Row, int Col), char>()
        {
            {(1, 2), '-'},
            {(2, 1), '|'},
        };

        var actualNeighbors = Grid.GetNeighbors(input, (1, 1));
        actualNeighbors.Should().BeEquivalentTo(expectedNeighbors);
    }
    [Test]
    public void CanGetNeigborsConsideringPoint()
    {
        var input = new string[] {
            "||L|.",
            ".L-J.",
        };
        var expectedNeighbors = new Dictionary<(int Row, int Col), char>()
        {
            {(1, 1), 'L'},
        };

        var actualNeighbors = Grid.GetNeighbors(input, (0, 1));
        actualNeighbors.Should().BeEquivalentTo(expectedNeighbors);
    }
}