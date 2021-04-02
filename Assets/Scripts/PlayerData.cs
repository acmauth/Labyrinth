[System.Serializable]
public class PlayerData
{
    public string username;
    public float avgTime; // in seconds
    public float score;

    public PlayerData()
    {
        username = "";
        avgTime= 0f;
        score = 0f;
    }

    public PlayerData(string username, float time, float score)
    {
        this.username = username;
        this.avgTime = time;
        this.score = score;
    }
}
