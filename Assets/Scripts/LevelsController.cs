using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class represents a controller for the levels. It contains all of the levels.
 *
 * Η κλάση αυτή αναπαραστά ένα controller για τα επίπεδα. Περιέχει όλα τα επίπεδα.
 */
public class LevelsController : MonoBehaviour
{
    public GetUsername username;
    
    public List<Level> levels;

    // Start is called before the first frame update
    void Start()
    {
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
        
        //CheckLevels(username.playerPos);
        CheckLevels(CurrentPlayer.GetPosition());
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
            Debug.Log("Going to Level " + level);
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            Debug.Log("Level " + level + " not unlocked.");
        }
    }
    
    private void CheckLevels(int playerPos)
    {
        foreach (Level level in levels)
        {
            level.CheckUnlocked(playerPos);
            //Debug.Log(level.level);
        }
    }

    private void OnEnable()
    {
        if (username != null)
        {
            username.FindPlayer();
        }
        
        CheckLevels(CurrentPlayer.GetPosition());
    }
}
