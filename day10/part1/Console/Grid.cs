
public class Grid
{
    public static Dictionary<(int Row, int Col), char> GetNeighbors(string[] input, (int Row, int Col) startingPoint)
    {
        var indexedValues = input
            .SelectMany((row, rowIndex) => row.Select((value, colIndex) => new Point(Value: value, Row: rowIndex, Col: colIndex)))
            .ToDictionary(
                point => (point.Row, point.Col),
                point => point.Value
        );

        var neighbors = indexedValues
            .SelectMany(keyValue => {
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

                var returnValue = new KeyValuePair<(int Row, int Col), char>[] {keyValue};
                if (isNorth && northTiles.Contains(currentPipe))
                    return returnValue;
                if (isSouth && southTiles.Contains(currentPipe))
                    return returnValue;
                if (isEast && eastTiles.Contains(currentPipe))
                    return returnValue;
                if (isWest && westTiles.Contains(currentPipe))
                    return returnValue;

                return [];
            })
            .ToDictionary(x => x.Key, x => x.Value);

        return neighbors;
    }
}

public record Point(int Row, int Col, char Value);