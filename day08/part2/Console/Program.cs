// See https://aka.ms/new-console-template for more information
using System.Text.Json;

var input = File.ReadAllLines("testInput.txt");
// var input = File.ReadAllLines("testInput2.txt");
// var input = File.ReadAllLines("realInput.txt");

Dictionary<string, string> nodes = getNodes(input);

var instructions = input[0].ToCharArray();
// Console.WriteLine(JsonSerializer.Serialize(nodes));
// System.Console.WriteLine();


// Console.WriteLine(instructions);

var pathStarts = nodes.Keys.Select(k => k[0..^1]).Where(k => k.EndsWith('A')).Distinct();
// Console.WriteLine(JsonSerializer.Serialize(pathStarts));



var location = pathStarts.First()[..^1];

var cycles = pathStarts.Select(s => getPathInfo(s, instructions, nodes)).ToArray();


cycles.ToList().ForEach(c => Console.WriteLine(c));


var zIndexesByCycle = cycles.Select(c => new Dictionary<int, int>()).ToList();

Console.WriteLine(JsonSerializer.Serialize(zIndexesByCycle));


var cycleLocations = cycles.Select(c => c.offset).ToList();

while(true)
{
    // cycleLocations = cycles
    //     .Select((c, i) => cycleLocations[i] + c.cycleLength)
    //     .ToArray();

    for(int i = 0; i < cycleLocations.Count; i++)
    {
      cycleLocations[i] += cycles[i].cycleLength;
      if(zIndexesByCycle[i].ContainsKey(cycleLocations[i]))
      {
        zIndexesByCycle[i][cycleLocations[i]] = cycleLocations[i];
      }
    }
    Console.WriteLine(JsonSerializer.Serialize(zIndexesByCycle));
}


// var longestOffset = cycles.Max(c => c.offset);
// var cycleLocationCount = cycles.Select(c => c.offset).ToArray();
// var count = 0;

// for(int i = 0; i < longestOffset; i++)
// {
//     cycleLocationCount = cycles
//         .Select((c, i) => cycleLocationCount[i] + c.cycleLength)
//         .ToArray();
//     count++;
// }
// System.Console.WriteLine();
// System.Console.WriteLine(count);
// Console.WriteLine(JsonSerializer.Serialize(cycleLocationCount));


// while(!cycleLocationCount
//     .Select((location, index) => (location, index))
//     .All((a) => cycles[a.index].zIndexes.Contains(a.location) )
// )
// {
//     cycleLocationCount = cycles
//         .Select((c, i) => cycleLocationCount[i] + c.cycleLength)
//         .ToArray();
//     count++;
// }
// System.Console.WriteLine(count);



// var steps = 0;

// while (!pathStarts.All(p => p.EndsWith('Z')))
// {
//     var nextInstruction = instructions[steps % instructions.Length];
//     // System.Console.WriteLine(current);

//     pathStarts = pathStarts.Select(p => nextInstruction switch
//     {
//         'R' => nodes[p + "R"],
//         'L' => nodes[p + "L"],
//     });

//     // Console.WriteLine(JsonSerializer.Serialize(paths));
//     steps++;
// }

static Dictionary<string, string> getNodes(string[] input)
{
    var leftNodes = input[2..].ToDictionary(
        l => l.Split("=")[0].Trim() + "L",
        l => l.Split("= ")[1].Split(", ")[0].Split("(")[1]
    );
    var rightNodes = input[2..].ToDictionary(
        l => l.Split("=")[0].Trim() + "R",
        l => l.Split("= ")[1].Split(", ")[1].Split(")")[0]
    );
    IEnumerable<Dictionary<string, string>> bothNodes = [leftNodes, rightNodes];
    var nodes = bothNodes.SelectMany(x => x).ToDictionary(x => x.Key, y => y.Value);
    return nodes;
}

static (int offset, int cycleLength, int[] zIndexes) getPathInfo(string location, char[] instructions, Dictionary<string, string> nodes)
{
    List<IndexedLocation> visited = [];

    var current = new IndexedLocation(location, instructions[0]);
    var nextInstruction = instructions[0];
    var zIndexes = new List<int>();

    while (!visited.Contains(current))
    {
        visited.Add(current);

        location = nextInstruction switch
        {
            'R' => nodes[location + "R"],
            'L' => nodes[location + "L"],
        };
        nextInstruction = instructions[visited.Count % instructions.Length];

        current = new IndexedLocation(location, nextInstruction);
        if (location.EndsWith('Z'))
            zIndexes.Add(visited.Count);
    }

    var offset = visited.FindIndex(l => l == current);
    var cycleLength = visited.Count - offset;

    // Console.WriteLine(JsonSerializer.Serialize(visited));
    // Console.WriteLine((offset, cycleLength));

    // System.Console.WriteLine();

    Console.WriteLine(JsonSerializer.Serialize(visited));
    Console.WriteLine(JsonSerializer.Serialize(zIndexes.ToArray()));
    System.Console.WriteLine();


    return (offset - 1, cycleLength, zIndexes.ToArray());
}

record IndexedLocation(string Location, char Direction);