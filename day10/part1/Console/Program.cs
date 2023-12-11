

using System.Drawing;

var input = File.ReadAllLines("testInput.txt");

var indexedValues = input
    .SelectMany((row, rowIndex) => row.Select((value, colIndex) => new Point(Value: value, Row: rowIndex, Col: colIndex)))
    .ToDictionary(
        point => (point.Row, point.Col),
        point => point.Value
    );

var startPoint = indexedValues.First((Point) => Point.Value == 'S');

