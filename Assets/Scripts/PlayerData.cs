[System.Serializable]
public class PlayerData
{
    public string username;
    public float avgTime; // in seconds
    public float score;
    public UnlockedLevels levels;

    public PlayerData()
    {
        username = "";
        avgTime= 0f;
        score = 0f;
        levels = new UnlockedLevels();
    }

    public PlayerData(string username, float time, float score)
    {
        this.username = username;
        this.avgTime = time;
        this.score = score;
        this.levels = new UnlockedLevels();
    }

    public PlayerData(string username, float time, float score, UnlockedLevels levels)
    {
        this.username = username;
        this.avgTime = time;
        this.score = score;
        this.levels = levels;
    }
}
