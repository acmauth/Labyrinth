using System.Collections.Generic;

/*
 * This class represents the stats of the game.
 *
 * Η κλάση αυτή αναπαραστά τα stats του παιχνιδιού.
 */
[System.Serializable]
public class Stats
{
    public List<KeyValuePair<string, float>> stats;

    public Stats()
    {
        stats = new List<KeyValuePair<string, float>>();
        for (int i = 0; i < 10; ++i)
        {
            stats.Add(new KeyValuePair<string, float>("AAA", 0));
        }
    }

    public Stats(string username, int score)
    {
        stats = new List<KeyValuePair<string, float>>{ new KeyValuePair<string, float>(username,score) };
    }

    public void Add(KeyValuePair<string, float> pair)
    {
        stats.Add(pair);
        stats.Sort((a,b)=>a.Value.CompareTo(b.Value));
        stats.Reverse();
        stats.RemoveAt(stats.Count-1);
    }
}
