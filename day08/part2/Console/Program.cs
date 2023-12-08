// See https://aka.ms/new-console-template for more information
using System.Text.Json;

// var input = File.ReadAllLines("testInput.txt");
// var input = File.ReadAllLines("testInput2.txt");
var input = File.ReadAllLines("realInput.txt");

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


var instructions = input[0].ToCharArray();


Console.WriteLine(JsonSerializer.Serialize(nodes));
Console.WriteLine(instructions);

var paths = nodes.Keys.Select(k => k[0..^1]).Where(k => k.EndsWith('A'));
Console.WriteLine(JsonSerializer.Serialize(paths));

var steps = 0;

while (!paths.All(p => p.EndsWith('Z')))
{
    var nextInstruction = instructions[steps % instructions.Length];
    // System.Console.WriteLine(current);

    paths = paths.Select(p => nextInstruction switch
    {
        'R' => nodes[p+"R"],
        'L' => nodes[p+"L"],
    });

    // Console.WriteLine(JsonSerializer.Serialize(paths));
    steps++;
}


System.Console.WriteLine(steps);