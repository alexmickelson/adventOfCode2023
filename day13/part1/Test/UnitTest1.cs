using FluentAssertions;

namespace Test;

public class Tests
{

    [Test]
    public void HorizontalMirrorTest()
    {
        var rows = new string[]
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "#.##..##.",
            "..##..##.",
            "#.#.##.#.",
        };

        Map.IsHorizontalMirror(rows, 2).Should().BeTrue();
    }
    [Test]
    public void HorizontalTest_IsFalseWhenNotTrue()
    {
        var rows = new string[]
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
        };

        Map.IsHorizontalMirror(rows, 2).Should().BeFalse();
    }
    [Test]
    public void HorizontalTest_IsFalseWhenNotTrue2()
    {
        var rows = new string[]
        {
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#",
        };

        Map.IsHorizontalMirror(rows, 2).Should().BeFalse();
    }

    [Test]
    public void HorizontalTest_IsFalseWhenNotTrue3()
    {
        var rows = new string[]
        {
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#",
        };

        Map.IsHorizontalMirror(rows, 6).Should().BeFalse();
    }

    [Test]
    public void HorizontalTest_IsTrueAtFirstMirror()
    {
        var rows = new string[]
        {
            "#...##..#",
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "..##..###",
            "#....#..#",
        };

        Map.IsHorizontalMirror(rows, 0).Should().BeTrue();
    }

    [Test]
    public void HorizontalTest_IsTrueAlastMirror()
    {
        var rows = new string[]
        {
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "..##..###",
            "#....#..#",
            "#....#..#",
        };

        Map.IsHorizontalMirror(rows, 5).Should().BeTrue();
    }

    [Test]
    public void VerticallMirrorTest()
    {
        var rows = new string[]
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
        };

        Map.IsVerticalMirror(rows, 4).Should().BeTrue();
    }
    [Test]
    public void VerticallMirrorTest2()
    {
        var rows = new string[]
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
        };

        Map.IsVerticalMirror(rows, 3).Should().BeFalse();
    }
    [Test]
    public void VerticallMirrorTest_TrueAtStart()
    {
        var rows = new string[]
        {
            "##.##.##.",
            "...#.#.#.",
            "###.....#",
            "###.....#",
            "...#.#.#.",
            "...##.##.",
            "##.#.#.#.",
        };

        Map.IsVerticalMirror(rows, 0).Should().BeTrue();
    }
    [Test]
    public void VerticallMirrorTest_TrueAtEnd()
    {
        var rows = new string[]
        {
            "#.##.##..",
            "..#.#.#..",
            "##.....##",
            "##.....##",
            "..#.#.#..",
            "..##.##..",
            "#.#.#.#..",
        };

        Map.IsVerticalMirror(rows, 7).Should().BeTrue();
    }
    [Test]
    public void VerticallMirrorTest_falseAtEnd()
    {
        var rows = new string[]
        {
            "#.##.##..",
            "..#.#.#..",
            "##.....##",
            "##.....##",
            "..#.#.#..",
            "..##.##..",
            "#.#.#.#..",
        };

        Map.IsVerticalMirror(rows, 8).Should().BeFalse();
    }

    [Test]
    public void CanGetVertical()
    {
        var rows = @".##...#..##
.....##...#
#..#..###..
#..#####..#
####.##.##.
####.##.##.
#..#####..#
#..##.###..
.....##...#
.##...#..##
.##..#.##.#
........###
.....#...#.
....#.#.##.
#..##..###.
#..###..#.#
#..#...#.##";
        
        var indexes = Map.GetVerticalMirrors(rows);
        indexes.Should().BeEquivalentTo([1]);
    }
}