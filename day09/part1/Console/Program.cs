
var input = File.ReadAllLines("realInput.txt");
// var input = File.ReadAllLines("testInput.txt");


var numberLines = input.Select(i => i.Split(" ").Select(n => int.Parse(n)));


var nextNumbers = numberLines.Select(l =>{
  var steps = Oasis.GenerateSteps(l.ToArray());
  return Oasis.PredictNextNumber(steps);
});

Console.WriteLine(nextNumbers.Sum());