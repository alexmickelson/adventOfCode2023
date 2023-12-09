public class Oasis
{
  public static int[][] GenerateSteps(int[] input)
  {

    int[][] stepArrays = [input];

    while (!stepArrays[^1].All(i => i == 0))
    {
      var (nextRow, _) = stepArrays[^1][1..]
        .Aggregate(
          (newList: new int[] { }, previous: stepArrays[^1][0]),
          (agg, i) =>
          {
            var newDiff = i - agg.previous;
            return ([..agg.newList, newDiff], i);
          }
        );
      stepArrays = [..stepArrays, nextRow];
    };

    return stepArrays;
  }

  public static int PredictNextNumber(int[][] input)
  {
    var next = input[^1][^1];
    foreach(var l in input[..^1].Reverse())
    {
      next += l[^1];
    }
    return next;
  }


  public static int PredictPreviousNumber(int[][] input)
  {
    var next = input[^1][0];
    foreach(var l in input[..^1].Reverse())
    {
      next = l[0] - next;
    }
    return next;
  }
}