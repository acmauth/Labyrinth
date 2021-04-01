using System.Collections.Generic;

/*
 * This class represents the stats of the game.
 *
 * Η κλάση αυτή αναπαραστά τα stats του παιχνιδιού.
 */
[System.Serializable]
public class Stats
{
    public List<KeyValuePair<string, int>> stats;

    public Stats()
    {
        stats = new List<KeyValuePair<string, int>>();
        for (int i = 0; i < 10; ++i)
        {
            stats.Add(new KeyValuePair<string, int>("AAA", 0));
        }
    }

    public Stats(string username, int score)
    {
        stats = new List<KeyValuePair<string, int>>{ new KeyValuePair<string, int>(username,score) };
    }

    public void Add(KeyValuePair<string, int> pair)
    {
        stats.Add(pair);
        stats.Sort((a,b)=>a.Value.CompareTo(b.Value));
        stats.Reverse();
        stats.RemoveAt(stats.Count-1);
    }
}
