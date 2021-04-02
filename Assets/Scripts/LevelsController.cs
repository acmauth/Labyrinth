using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class represents a controller for the levels. It contains all of the levels.
 *
 * Η κλάση αυτή αναπαραστά ένα controller για τα επίπεδα. Περιέχει όλα τα επίπεδα.
 */
public class LevelsController : MonoBehaviour
{
    public InputField usernameField;
    
    public List<Level> levels;

    // Start is called before the first frame update
    void Start()
    {
        if (usernameField == null)
        {
            usernameField = FindObjectOfType<InputField>();
        }
        
        // If the levels are not specified in the inspector then find all the objects that have a Level script
        if (levels == null)
        {
            levels = new List<Level>();
            
            Level[] getLevels = FindObjectsOfType<Level>();
            foreach (Level level in getLevels)
            {
                levels.Add(level);
            }
        }
        
        // Sort the levels
        levels.Sort((a,b)=>a.level.CompareTo(b.level));
        
        CheckLevels();
    }

    /*
     * This method is called when a level-button is pressed. It takes that level's number and checks if it is unlocked. Then it goes to the
     * appropriate scene.
     *
     * Η μέθοδος καλείται όταν ένα κουμπί-επίπεδο πατιέται. Παίρνει τον αριθμό του επιπέδου και ελέγχει αν είναι ξεκλέιδωτο. Τότε πάει στην κατάλληλη
     * σκηνή.
     */
    public void ChooseLevel(int level)
    {
        if (levels[level-1].Unlocked())
        {
            GetUsername();

            Debug.Log("Going to Level " + level);
            //SceneManager.LoadScene("Level" + level);
            
            
            
            // Temporary (When the levels are implemented this will be deleted)
            SaveSystem.currentPath = SaveSystem.levelsPath;
            UnlockedLevels unclocked = SaveSystem.Load<UnlockedLevels>();
            unclocked.AddUnlocked(level);
            unclocked.AddCompleted(level);
            SaveSystem.Save(unclocked);
            CheckLevels();
        }
        else
        {
            Debug.Log("Level " + level + " not unlocked.");
        }
    }
    
    private void CheckLevels()
    {
        foreach (Level level in levels)
        {
            level.CheckUnlocked();
            //Debug.Log(level.level);
        }
    }

    private void GetUsername()
    {
        // Search for a player in our database with the same username of the text field
        SaveSystem.currentPath = SaveSystem.statsPath;
        Stats stats = SaveSystem.Load<Stats>();
        if (stats == null) stats = new Stats();
            
        PlayerData data = new PlayerData();
        foreach (var player in stats.stats)
        {
            if (player.username == usernameField.text)
            {
                data = player;
                Debug.Log("Found Player");
            }
        }

        // If the player if not found then create a new player with the given username and add it to the database
        if (data.username == "")
        {
            data.username = usernameField.text;
            Debug.Log("Player not found.");
        }
        stats.Add(data);
        SaveSystem.Save(stats);
    }
}
