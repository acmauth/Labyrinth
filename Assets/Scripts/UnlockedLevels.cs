using System.Collections.Generic;

/*
 * This class represents the levels that have been unlocked.
 *
 * Η κλάση αυτή αναπαραστά τα επίπεδα που έχουν ολοκληρωθεί.
 */
[System.Serializable]
public class UnlockedLevels
{
    public List<int> unlocked; // Unlocked levels
    public List<int> completed; // Completed levels

    public UnlockedLevels()
    {
        unlocked = new List<int> {0};
        completed = new List<int> {0};
    }

    public void AddUnlocked(int level)
    {
        if (unlocked.Contains(level)) return;
        unlocked.Add(level);
        unlocked.Sort();
    }

    public void AddCompleted(int level)
    {
        if (completed.Contains(level)) return;
        completed.Add(level);
        completed.Sort();
    }
}
