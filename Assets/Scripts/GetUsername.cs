using UnityEngine;
using UnityEngine.UI;

/*
 * This class get the username from the input field and checks to see if the player already exists in the
 * database. If not it creates an new player in the database with this username.
 *
 * Αυτή η κλάση παίρνει το username που έδωσε ο χρήστης και βλέπει αν υπάρχει παίκτης με το ίδιο username.
 * Αν δεν υπάρχει τότε δημιουργεί ένα καινούργιο παίκτη με αυτό το username.
 */
public class GetUsername : MonoBehaviour
{
    public InputField field;

    // Start is called before the first frame update
    void Start()
    {
        // Null check
        if (field == null)
        {
            field = FindObjectOfType<InputField>();
        }
    }

    public void FindPlayer()
    {
        // Search for a player in our database with the same username of the text field
        SaveSystem.currentPath = SaveSystem.statsPath;
        Stats stats = SaveSystem.Load<Stats>();
        if (stats == null) stats = new Stats();
        
        int j = 0;
        int position;
        foreach (var player in stats.stats)
        {
            if (player.username == field.text)
            {
                position = j;
                CurrentPlayer.ChangePosition(position);
                //Debug.Log("Found Player");
                return;
            }

            j++;
        }

        // If the player if not found then create a new player with the given username and add it to the database
        PlayerData data = new PlayerData(field.text, 0f, 0f);
        //Debug.Log("Player not found.");
        
        stats.Add(data);
        SaveSystem.Save(stats);

        position = 0;
        bool flag = true;
        for (int i = 0; i < stats.stats.Count && flag; ++i)
        {
            if (data.username == stats.stats[i].username)
            {
                position = i;
                flag = false;
            }
        }

        CurrentPlayer.ChangePosition(position);
    }
}
