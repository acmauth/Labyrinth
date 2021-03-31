using System.Collections.Generic;

[System.Serializable]
public class Stats
{
    public List<int> scores;
    public List<string> usernames;

    public Stats()
    {
        scores = new List<int>(10);
        usernames = new List<string>(10);
        for (int i = 0; i < scores.Capacity; i++)
        {
            scores.Add(0);
            usernames.Add("AAA");
        }
    }

    public Stats(List<int> scores, List<string> usernames)
    {
        this.scores = scores;
        this.usernames = usernames;
    }

    public void Add(int score, string username)
    {
        this.scores.Add(score);
        this.usernames.Add(username);
            
        this.scores.Sort();
        this.usernames.Sort();

        if (this.scores.Count > 10)
        {
            this.scores.RemoveAt(0);
            this.usernames.RemoveAt(0);
        }
        
        this.scores.Reverse();
        this.usernames.Reverse();
    }
}
