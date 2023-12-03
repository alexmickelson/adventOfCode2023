using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

public class Schematics
{
  public static IEnumerable<int> GetPartNumbers(string input)
  {
    var lines = input.Split(Environment.NewLine);
    var output = GetNumberRangesFromString(lines.First());
    return [];
  }

  public static IEnumerable<(int startIndex, int endIndex)> GetNumberRangesFromString(string line)
  {
    var output = new List<(int startIndex, int endIndex)>();

    int? currentStart = null;
    for(int i = 0; i < line.Length; i++)
    {
      if(currentStart == null && char.IsDigit(line[i]))
      {
        currentStart = i;
      }
      else if (currentStart != null && !char.IsDigit(line[i]))
      {
        output.Add(((int)currentStart, i - 1));
        currentStart = null;
      }
    }

    if(currentStart != null)
      output.Add(((int) currentStart, line.Length - 1));

    return output;
  }

  public static bool IsPartNumber((int startIndex, int endIndex) numberIndex, int rowNumber, string[] rows)
  {
    
    (int startIndex, int endIndex) = numberIndex;

    var validColumn = (int c) => c >= 0 &&  c < rows[rowNumber].Length ;
    var validRow = (int r) => r >= 0  && r < rows.Length;

    for(int r = rowNumber - 1; r <= rowNumber + 1; r++)
    {
      for(int c = startIndex - 1; c <= endIndex + 1; c++)
      {
        if(validColumn(c) && validRow(r))
        {
          var symbol = rows[r][c];
          if(!char.IsDigit(symbol) && symbol != '.')
          {
            return true;
          }
        }
      }
    }
    return false;
  }
}