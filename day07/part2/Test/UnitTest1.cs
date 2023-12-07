using System.ComponentModel;
using FluentAssertions;

namespace Test;

public class Tests
{
    [Test]
    public void FiveOfAKind_Beats_FourOfaKind()
    {
        Poker.CompareHand("AAAAA", "AA8AA").Should().Be(1);
    }

    [Test]
    public void FiveOfAKind_Beats_FourOfaKind2()
    {
        Poker.CompareHand("AA8AA", "AAAAA").Should().BeLessThanOrEqualTo(-1);
    }

    [Test]
    public void FiveOfAKind_Tie_beatByLargerValue()
    {
        Poker.CompareHand("AAAAA", "KKKKK").Should().Be(1);
    }

    [Test]
    public void FiveOfAKind_Tie_beatByLargerValue2()
    {
        Poker.CompareHand("KKKKK", "AAAAA").Should().BeLessThanOrEqualTo(-1);
    }

    [Test]
    public void fullHouse_beats_threeOfKind()
    {
        Poker.CompareHand("23332", "TTT98").Should().Be(1);
    }
    
    [Test]
    public void fullHouse_beats_threeOfKind1()
    {
        Poker.CompareHand("TTT98", "23332").Should().BeLessThanOrEqualTo(-1);;
    }
    
    [Test]
    public void fullHouse_comparesbyvalue()
    {
        Poker.CompareHand("23332", "TTT88").Should().BeLessThan(0);
    }
    
    [Test]
    public void fullHouse_comparesbyvalue2()
    {
        Poker.CompareHand("TTT88", "23332").Should().BeGreaterThan(0);
    }
    [Test]
    public void twoPair_beats_onePair()
    {
        Poker.CompareHand("AKQ55", "KKQ55").Should().BeLessThan(0);
    }
    
    [Test]
    public void twoPair_beats_onePair2()
    {
        Poker.CompareHand("KKQ55", "AKQ55").Should().BeGreaterThan(0);
    }
    
    [Test]
    public void fullhouse_beats_twopair()
    {
        Poker.CompareHand("22255", "AAQ55").Should().BeGreaterThan(0);
    }
    [Test]
    public void fullhouse_beats_twopair2()
    {
        Poker.CompareHand("AAQ55", "22255").Should().BeLessThan(0);
    }

    [Test]
    public void onepair_beats_highcard()
    {
        Poker.CompareHand("23456", "54322").Should().BeLessThan(0);
    }

    [Test]
    public void onepair_beats_highcard2()
    {
        Poker.CompareHand("54322", "23456").Should().BeGreaterThan(0);
    }

    [Test]
    public void twopair_sameRank_comparevalue()
    {
        Poker.CompareHand("KK677", "KT55T").Should().BeGreaterThan(0);
    }
    [Test]
    public void twopair_sameRank_comparevalue2()
    {
        Poker.CompareHand("KT55T", "KK677").Should().BeLessThan(0);
    }
    [Test]
    public void three_beats_two()
    {
        Poker.CompareHand("22345", "22234").Should().BeLessThan(0);
    }
    [Test]
    public void three_beats_two2()
    {
        Poker.CompareHand("22234", "22345").Should().BeGreaterThan(0);
    }
    [Test]
    public void otherTest()
    {
        Poker.CompareHand("22222", "23456").Should().BeGreaterThan(0);
    }
    [Test]
    public void highCard_ordersByScore()
    {
        Poker.CompareHand("AKQ59", "23456").Should().BeGreaterThan(0);
    }
    
}