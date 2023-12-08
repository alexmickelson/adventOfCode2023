// See https://aka.ms/new-console-template for more information
using System.Text.Json;

// var input = File.ReadAllLines("testInput.txt");
// var input = File.ReadAllLines("testInput2.txt");
var input = File.ReadAllLines("realInput.txt");

var nodes = input[2..].ToDictionary(
    l => l.Split("=")[0].Trim(),
    l => new {
        Left = l.Split("= ")[1].Split(", ")[0].Split("(")[1],
        Right = l.Split("= ")[1].Split(", ")[1].Split(")")[0],
    }
);


var instructions = input[0].ToCharArray();


System.Console.WriteLine(JsonSerializer.Serialize(nodes));
System.Console.WriteLine(instructions);

var current = "AAA";
var steps = 0;

while(current != "ZZZ")
{
    var nextInstruction = instructions[steps % instructions.Length];
    System.Console.WriteLine(current);
    current = nextInstruction switch
    {
        'R' => nodes[current].Right,
        'L' => nodes[current].Left,
    };
    steps++;
}


System.Console.WriteLine(steps);