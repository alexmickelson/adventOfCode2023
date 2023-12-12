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
    
}