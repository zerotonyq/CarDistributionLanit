namespace CarDistribution.Application.Distribution;

public class DistributionHandler
{
    public static int GetIdByProbability(KeyValuePair<int, int> idQuantityFirst, KeyValuePair<int, int> idQuantitySecond)
    {
        float edge = 0;
        
        float resultValue;
        
        Random rand = new Random();
        
        if (idQuantityFirst.Value == idQuantitySecond.Value)
            edge = 1.0f / 2.0f;
        else if (Math.Abs(idQuantityFirst.Value - idQuantitySecond.Value) == 1)
            edge = 1.0f / 3f * 2f;
        else if (Math.Abs(idQuantityFirst.Value - idQuantitySecond.Value) == 2)
            edge = 1f / 5f * 4f;
        else if (Math.Abs(idQuantityFirst.Value - idQuantitySecond.Value) == 3) 
            edge = 1f;
        
        resultValue = rand.NextSingle();

        var lessQuantityId = Math.Min(idQuantityFirst.Value, idQuantitySecond.Value) == idQuantityFirst.Value
            ? idQuantityFirst.Key
            : idQuantitySecond.Key;
        var biggerQuantityId = Math.Max(idQuantityFirst.Value, idQuantitySecond.Value) == idQuantityFirst.Value
            ? idQuantityFirst.Key
            : idQuantitySecond.Key;
        
        return resultValue <= edge ? lessQuantityId : biggerQuantityId;
    }
}