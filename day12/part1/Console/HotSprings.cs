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
        var nextDamageIndex = damagedRecord.IndexOf('?');

        if(nextDamageIndex == -1)
        {
            var actualCounts = damagedRecord.Split('.').Where(s => s != string.Empty).Select(s => s.Count());

            if(actualCounts.SequenceEqual(conditionOrder))
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
}