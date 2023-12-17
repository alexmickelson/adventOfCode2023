
using System.Collections.Concurrent;
using System.Diagnostics;

// var input = File.ReadAllLines("testInput.txt");
var input = File.ReadAllLines("realInput.txt");

// var result = input
//     .Select(r => HotSprings.Expand(r))
//     .Select(r => HotSprings.GetArrangementCount(r)).Sum();


ThreadPool.GetMaxThreads(out int workerthreads, out int completionPortthreads);
System.Console.WriteLine(workerthreads);
System.Console.WriteLine(completionPortthreads);

var timer = new Stopwatch();
timer.Start();
var ways = new ConcurrentBag<int>();

Parallel.ForEach(input, (row) =>
{
    var expanded = HotSprings.Expand(row);
    var localWays = HotSprings.GetArrangementCount(expanded);
    ways.Add(localWays);
    Console.WriteLine($"completed {ways.Count} of {input.Count()}");
});

System.Console.WriteLine(ways.Sum());
Console.WriteLine("calculation execution time = {0} seconds", timer.Elapsed.TotalSeconds);
