

public class Grid
{
    public static IEnumerable<(int Row, int Col)> GetNeighbors(Dictionary<(int Row, int Col), char> indexedValues, (int Row, int Col) startingPoint)
    {

        Directions[] validDirections = indexedValues[(startingPoint.Row, startingPoint.Col)] switch
        {
            '|' => [Directions.North, Directions.South],
            '-' => [Directions.East, Directions.West],
            'L' => [Directions.North, Directions.East],
            'J' => [Directions.West, Directions.North],
            '7' => [Directions.West, Directions.South],
            'F' => [Directions.East, Directions.South],
            'S' => [Directions.North, Directions.East, Directions.South, Directions.West],
            _ => [],
        };

        var checkPoints = new (int row, int col)[] {
            (startingPoint.Row - 1, startingPoint.Col),
            (startingPoint.Row + 1, startingPoint.Col),
            (startingPoint.Row, startingPoint.Col + 1),
            (startingPoint.Row, startingPoint.Col - 1),
        };

        var neighbors = indexedValues
            .Where(keyValue => checkPoints.Contains(keyValue.Key))
            .SelectMany(keyValue =>
            {
                var coordinates = keyValue.Key;
                var currentPipe = keyValue.Value;

                bool isNorth = coordinates.Row == startingPoint.Row - 1 && coordinates.Col == startingPoint.Col;
                bool isSouth = coordinates.Row == startingPoint.Row + 1 && coordinates.Col == startingPoint.Col;
                bool isEast = coordinates.Row == startingPoint.Row && coordinates.Col == startingPoint.Col + 1;
                bool isWest = coordinates.Row == startingPoint.Row && coordinates.Col == startingPoint.Col - 1;

                char[] northTiles = ['|', '7', 'F'];
                char[] southTiles = ['|', 'L', 'J'];
                char[] eastTiles = ['-', 'J', '7'];
                char[] westTiles = ['-', 'L', 'F'];



                var returnValue = new KeyValuePair<(int Row, int Col), char>[] { keyValue };
                if (isNorth && northTiles.Contains(currentPipe) && validDirections.Contains(Directions.North))
                    return returnValue;
                if (isSouth && southTiles.Contains(currentPipe) && validDirections.Contains(Directions.South))
                    return returnValue;
                if (isEast && eastTiles.Contains(currentPipe) && validDirections.Contains(Directions.East))
                    return returnValue;
                if (isWest && westTiles.Contains(currentPipe) && validDirections.Contains(Directions.West))
                    return returnValue;

                return [];
            });

        return neighbors.Select(k => k.Key);
    }
    public static Dictionary<(int Row, int Col), char> ParsePoints(string[] input)
    {
        return input
            .SelectMany((row, rowIndex) => row.Select((value, colIndex) => new Point(Value: value, Row: rowIndex, Col: colIndex)))
            .ToDictionary(
                point => (point.Row, point.Col),
                point => point.Value
        );
    }

    public static int LongestPointDistance(Dictionary<(int Row, int Col), char> input)
    {
        var startIndex = input.First(keyValue => keyValue.Value == 'S').Key;
        
        (int Row, int Col)[] lastPoints = [startIndex];
        var currentPoints = GetNeighbors(input, startIndex).ToArray();
        var steps = 1;

        var total = input.Count();
        System.Console.WriteLine(total);
        while(currentPoints[0] != currentPoints[1])
        {

            var nextPoints = currentPoints.SelectMany(p => GetNeighbors(input, p)).Where(p => !lastPoints.Contains(p)).ToArray();
            if(nextPoints.Count() != 2)
                throw new Exception($"wrong number of points, {nextPoints}");
            steps++;
            lastPoints = currentPoints;
            currentPoints = nextPoints;

            if(steps % 1000 == 0)
            {
                System.Console.WriteLine(steps);
            }
        }
        return steps;

    }

}

public record Point(int Row, int Col, char Value);

public enum Directions
{
    North,
    South,
    East,
    West
}