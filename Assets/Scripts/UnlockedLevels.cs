using System;
using System.Collections.Generic;

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
