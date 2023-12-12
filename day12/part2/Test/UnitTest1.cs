using FluentAssertions;

namespace Test;

public class Tests
{

    [Test]
    public void CanGetArrangementCount()
    {
        var row = "???.### 1,1,3";

        HotSprings.GetArrangementCount(row).Should().Be(1);
    }

    [Test]
    public void CanGetArrangementCount2()
    {
        var row = ".??..??...?##. 1,1,3";

        HotSprings.GetArrangementCount(row).Should().Be(4);
    }

    [Test]
    public void CanGetArrangementCount3()
    {
        var row = "?###???????? 3,2,1";

        HotSprings.GetArrangementCount(row).Should().Be(10);
    }
    

    [Test]
    public void CanExpand()
    {
        var input = ".# 1";
        var actual = HotSprings.Expand(input);

        var expected = ".#?.#?.#?.#?.# 1,1,1,1,1";

        actual.Should().Be(expected);
    }

    [Test, Sequential]
    public void CanAvoidCrashing(
        [Values(
            "???.### 1,1,3",
            ".??..??...?##. 1,1,3",
            "?#?#?#?#?#?#?#? 1,3,1,6",
            "????.#...#... 4,1,1",
            "????.######..#####. 1,6,5",
            "?###???????? 3,2,1"
        )] string input,
        [Values(
            1,
            16384,
            1,
            16,
            2500,
            506250
        )] int result
    )
    {
        var expanded = HotSprings.Expand(input);
      
        var actual = HotSprings.GetArrangementCount(expanded);

        actual.Should().Be(result);
    }
}