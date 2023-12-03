using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

public class Schematics
{
  public static IEnumerable<int> GetPartNumbers(string input)
  {
    var lines = input.Split(Environment.NewLine);
    IEnumerable<(int startIndex, int endIndex, int row)> outputRanges = GetNumberRangesFromStrings(lines);

    var outputNumbers = outputRanges.Select(range => ReadInt(range, lines));

    return outputNumbers;
  }

  public static IEnumerable<(int startIndex, int endIndex, int row)> GetNumberRangesFromStrings(string[] lines)
  {
    return lines.SelectMany((line, row) =>
    {
      var ranges = GetNumberRangesFromLine(line);
      return ranges
        .Where(r => IsPartNumber((r.startIndex, r.endIndex, row), lines))
        .Select(r => (r.startIndex, r.endIndex, row));
    });
  }

  public static int ReadInt((int startIndex, int endIndex, int row) range, string[] rows)
  {
    (int startIndex, int endIndex, int row) = range;
    var stringSegment = rows[row][startIndex..(endIndex + 1)];
    return int.Parse(stringSegment);
  }

  public static IEnumerable<(int startIndex, int endIndex)> GetNumberRangesFromLine(string line)
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

    var isSymbol = (string[] rows, int r, int c) =>
    {
      return !char.IsDigit(rows[r][c]) && rows[r][c] != '.';
    };

    return NumberRangeIsTouching(rows, isSymbol, numberIndex);
  }

  private static bool NumberRangeIsTouching(string[] rows, Func<string[], int, int, bool> isSymbol, (int startIndex, int endIndex, int rowNumber) numberIndex)
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
          if (isSymbol(rows, r, c))
          {
            return true;
          }
        }
      }
    }
    return false;
  }

  public static IEnumerable<(int row, int col)> GetGearRatioCenters(string[] lines)
  {
    var numbers = Schematics.GetPartNumbers(string.Join(Environment.NewLine, lines));
    List<(int row, int col)> stars = GetStarIndexes(lines);

    var numberRanges = Schematics.GetNumberRangesFromStrings(lines);
    return stars.Where(s => StarIsGearRatio(s, lines, numberRanges));
  }

  public static List<(int row, int col)> GetStarIndexes(string[] lines)
  {
    var stars = new List<(int row, int col)>();
    for (int r = 0; r < lines.Length; r++)
    {
      for (int c = 0; c < lines[r].Length; c++)
      {
        if (lines[r][c] == '*')
        {
          stars.Add((r, c));
        }
      }
    }

    return stars;
  }

  public static bool StarIsGearRatio(
    (int, int) starIndex, 
    string[] lines, 
    IEnumerable<(int startIndex, int endIndex, int row)> numberRanges
  )
  {
    (int startIndex, int endIndex, int row)[] numbersNextToStar = GetNumbersNextToStar(lines, numberRanges, starIndex);

    return numbersNextToStar.Count() == 2;
  }

  private static (int startIndex, int endIndex, int row)[] GetNumbersNextToStar(
    string[] lines, 
    IEnumerable<(int startIndex, int endIndex, int row)> numberRanges, 
    (int, int) starIndex
  )
  {

    var (starRow, starCol) = starIndex;
    var isStar = (string[] rows, int row, int col) =>
    {
      return row == starRow && col == starCol;
    };


    var numbersNextToStar = numberRanges.Where(r =>
    {
      return NumberRangeIsTouching(lines, isStar, r);
    }).ToArray();

    if (numbersNextToStar.Count() > 2)
      throw new Exception("Got too many numbers next to star, " + JsonSerializer.Serialize(numbersNextToStar));
    return numbersNextToStar;
  }

  public static int GetGearRatio(
    (int, int) starIndex, 
    string[] lines, 
    IEnumerable<(int startIndex, int endIndex, int row)> numberRanges
  )
  {
    (int startIndex, int endIndex, int row)[] numbersNextToStar = GetNumbersNextToStar(lines, numberRanges, starIndex);

    var numbers =  numbersNextToStar.Select(range => ReadInt(range, lines)).ToList();
    return numbers[0] * numbers[1];
  }
}