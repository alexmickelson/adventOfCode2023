using System.Text;

public class HotSprings
{
    public static int GetArrangementCount(string row)
    {
        var conditionOrder = row.Split(" ")[1].Split(",").Select(c => int.Parse(c)).ToArray();

        var damagedRecord = row.Split(" ")[0];


        return innerAragementCount(damagedRecord, conditionOrder);
    }

    private static int innerAragementCount(string damagedRecord, int[] conditionOrder)
    {
        var knownConditionOrder = GetActualHotSpringNumbers(damagedRecord).ToArray();
        var lengthOfNumbersToCheck = knownConditionOrder.Count() - 1;


        if(lengthOfNumbersToCheck > (conditionOrder.Count() -1 ))
            return 0;

        if (lengthOfNumbersToCheck > 0 
            && !conditionOrder[..lengthOfNumbersToCheck].SequenceEqual(knownConditionOrder[..^1])
        )
            return 0;


        var nextDamageIndex = damagedRecord.IndexOf('?');

        if (nextDamageIndex == -1)
        {
            var actualCounts = GetActualHotSpringNumbers(damagedRecord);

            if (actualCounts.SequenceEqual(conditionOrder))
                return 1;
            else
                return 0;
        }

        var stringFixed1 = new StringBuilder(damagedRecord);
        stringFixed1[nextDamageIndex] = '#';

        var stringFixed2 = new StringBuilder(damagedRecord);
        stringFixed2[nextDamageIndex] = '.';

        return innerAragementCount(stringFixed1.ToString(), conditionOrder) + innerAragementCount(stringFixed2.ToString(), conditionOrder);
    }

    private static IEnumerable<int> GetActualHotSpringNumbers(string damagedRecord)
    {
        var knownRecord = damagedRecord;
        if (damagedRecord.Contains('?'))
            knownRecord = damagedRecord.Split('?')[0];


        return knownRecord.Split('.').Where(s => s != string.Empty).Select(s => s.Count());


    }

    public static string Expand(string input)
    {
        var conditionOrder = input.Split(" ")[1].Split(",");

        var damagedRecord = input.Split(" ")[0];

        var damagedRecordExpanded = string.Join("?", Enumerable.Repeat(damagedRecord, 5));
        var conditionOrderExpanded = string.Join(",", Enumerable.Repeat(conditionOrder, 5).SelectMany(s => s));
        return damagedRecordExpanded + " " + conditionOrderExpanded;
    }
}