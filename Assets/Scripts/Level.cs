using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class represents a Level. It has the associated button, the level number, its parent levels (so that we can check if this level is unlocked)
 * the unlocked levels from the save files, and a boolean for wether this level is unlocked.
 *
 * Αυτή η κλάση αναπαραστά ένα επίπεδο. Έχει το αντίστοιχο κουμπί, τον αριθμό του επιπέδου, τα επίπεδα-γονείς (ώστε να ελέγξουμε αν το επίπεδο είναι
 * ξεκλέιδωτο, τα ξεκλείδωτα επίπεδα από το αρχείο μας, και μία λογική μεταβλητή για τον αν το επίπεδο είναι ξεκλέιδωτο.
 */
public class Level : MonoBehaviour
{
    public Button button;
    public int level;
    public List<int> parentLevels;
    private UnlockedLevels levels;
    private bool unlocked; 

    // Start is called before the first frame update
    void Start()
    {
        // If we don't specify the parents from the inspector we take for granted that the parent is the previous level
        if (parentLevels == null)
        {
            parentLevels = new List<int> {level - 1};
        }

        // If the button is not specified from the inspector, find it
        if (button == null)
        {
            button = gameObject.GetComponent<Button>();
        }
    }

    public bool Unlocked()
    {
        return unlocked;
    }

    public void CheckUnlocked(int pos)
    {
        SaveSystem.currentPath = SaveSystem.statsPath;
        Stats stats = SaveSystem.Load<Stats>();
        levels = stats.stats[pos].levels;
        
        //Debug.Log("Checking level " + level + " for player : " + stats.stats[pos].username 
        //            + " at " + pos);

        // If this level is in the unlocked list then it is unlocked
        if (levels.unlocked.Contains(level))
        {
            unlocked = true;
            button.interactable = true;
            return;
        }
        
        unlocked = true;
        // If any of the parent levels are not in the completed levels then this level is not unlocked
        foreach (int parent in parentLevels)
        {
            if (!levels.completed.Contains(parent))
            {
                unlocked = false;
            }
        }

        // Set the button as interactable if the level is unlocked
        button.interactable = unlocked;

        if (unlocked)
        {
            stats.stats[pos].levels.AddUnlocked(level);
            SaveSystem.Save(stats);
        }
    }
}
