/*
 * This class represents the data of the player (the username and the score). When the player chooses a level then an object of this
 * class with the username from the input field and a score = 0 are saved in the appropriate file. When the player loses, the score will also be
 * saved and we will add the saved stats the saved object as a new stat.
 */

using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public string username;
    public float score;

    public PlayerData()
    {
        username = "";
        score = 0f;
    }

    public PlayerData(string username, float score)
    {
        this.username = username;
        this.score = score;
    }

    public KeyValuePair<string, float> ReturnPair()
    {
        return new KeyValuePair<string, float>(username, score);
    }
}
