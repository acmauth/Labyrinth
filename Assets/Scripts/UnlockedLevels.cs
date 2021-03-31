using System;
using System.Collections.Generic;

/*
 * This class represents the levels that have been unlocked.
 *
 * Η κλάση αυτή αναπαραστά τα επίπεδα που έχουν ολοκληρωθεί.
 */
[Serializable]
public class UnlockedLevels
{
    public List<int> unlocked;

    public UnlockedLevels()
    {
        unlocked = new List<int> {0};
    }

    public void Add(int level)
    {
        if (unlocked.Contains(level)) return;
        unlocked.Add(level);
        unlocked.Sort();
    }
}
