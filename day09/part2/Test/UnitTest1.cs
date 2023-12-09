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
  public void Test1()
  {
    int[] input = [
        0,    3,   6,   9,  12,  15
    ];

    var output = Oasis.GenerateSteps(input);

    int[][] expected = [
        [0,   3,   6,   9,  12,  15],
        [3,   3,   3,   3,   3,],
        [0,   0,   0,   0,],
    ];
    output.Should().BeEquivalentTo(expected);
  }
  [Test]
  public void Test2()
  {
    int[] input = [
       10,  13,  16,  21,  30,  45,  68
    ];

    var output = Oasis.GenerateSteps(input);

    int[][] expected = [
        [10,  13,  16,  21,  30,  45 , 68,],
        [3,   3,   5,   9,  15,  23,],
        [0,   2,   4,   6,   8,],
        [2,   2,   2,   2,],
        [0,   0,   0,],
    ];
    output.Should().BeEquivalentTo(expected);
  }

  [Test]
  public void TestPrediction()
  {
    int[][] input = [
        [0,   3,   6,   9,  12,  15],
        [3,   3,   3,   3,   3,],
        [0,   0,   0,   0,],
    ];

    var next = Oasis.PredictNextNumber(input);
    next.Should().Be(18);

  }
  [Test]
  public void TestPrediction2()
  {
    int[][] input = [
        [10,  13,  16,  21,  30,  45 ,],
          [3,   3,   5,   9,  15,  ],
          [0,   2,   4,   6,   ],
          [2,   2,   2,   ],
          [0,   0,   ],
      ];

    var next = Oasis.PredictNextNumber(input);
    next.Should().Be(68);
  }
  [Test]
  public void Backwards()
  {
    int[][] input = [
      [10,  13,  16,  21,  30,  45],
      [3,   3,   5,   9,  15,  ],
      [0,   2,   4,   6   ],
      [2,   2,   2,   ],
      [0,   0],
    ];

    var next = Oasis.PredictPreviousNumber(input);
    next.Should().Be(5);
  }
}