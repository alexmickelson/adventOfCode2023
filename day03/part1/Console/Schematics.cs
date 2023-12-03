using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

public class Schematics
{
  public static IEnumerable<int> GetPartNumbers(string input)
  {
    var lines = input.Split(Environment.NewLine);

    var outputRanges = lines.SelectMany((line, row) =>
    {
      var ranges = GetNumberRangesFromString(line);
      return ranges
        .Where(r => IsPartNumber((r.startIndex, r.endIndex, row), lines))
        .Select(r => (r.startIndex, r.endIndex, row));
    });

    var outputNumbers = outputRanges.Select(range => ReadInt(range, lines));

    return outputNumbers;
  }

  public static int ReadInt((int startIndex, int endIndex, int row) range, string[] rows)
  {
    (int startIndex, int endIndex, int row) = range;
    var stringSegment = rows[row][startIndex..(endIndex + 1)];
    return int.Parse(stringSegment);
  }

  public static IEnumerable<(int startIndex, int endIndex)> GetNumberRangesFromString(string line)
  {
    var output = new List<(int startIndex, int endIndex)>();

    int? currentStart = null;
    for (int i = 0; i < line.Length; i++)
    {
      if (currentStart == null && char.IsDigit(line[i]))
      {
        currentStart = i;
      }
      else if (currentStart != null && !char.IsDigit(line[i]))
      {
        output.Add(((int)currentStart, i - 1));
        currentStart = null;
      }
    }

    if (currentStart != null)
      output.Add(((int)currentStart, line.Length - 1));

    return output;
  }

  public static bool IsPartNumber((int startIndex, int endIndex, int rowNumber) numberIndex, string[] rows)
  {

    (int startIndex, int endIndex, int rowNumber) = numberIndex;

    var validColumn = (int c) => c >= 0 && c < rows[rowNumber].Length;
    var validRow = (int r) => r >= 0 && r < rows.Length;

    for (int r = rowNumber - 1; r <= rowNumber + 1; r++)
    {
      for (int c = startIndex - 1; c <= endIndex + 1; c++)
      {
        if (validColumn(c) && validRow(r))
        {
          var symbol = rows[r][c];
          if (!char.IsDigit(symbol) && symbol != '.')
          {
            return true;
          }
        }
      }
    }
    return false;
  }
}