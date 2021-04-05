using System.Collections.Generic;

/*
 * This class represents the stats of the game.
 *
 * Η κλάση αυτή αναπαραστά τα stats του παιχνιδιού.
 */
[System.Serializable]
public class Stats
{
    public List<PlayerData> stats;

    public Stats()
    {
        stats = new List<PlayerData>();
        for (int i = 0; i < 10; ++i)
        {
            stats.Add(new PlayerData("AAA", 0, 0));
        }
    }

    public void Add(PlayerData data)
    {
        stats.Add(data);
        Comp comparer = new Comp();
        stats.Sort(comparer);
        stats.Reverse();
    }
}
