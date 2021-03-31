using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    public List<Level> levels;
    private int currentLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        if (levels == null)
        {
            levels = new List<Level>();
            
            Level[] getLevels = FindObjectsOfType<Level>();
            foreach (Level level in getLevels)
            {
                levels.Add(level);
            }
        }
        
        levels.Sort((a,b)=>a.level.CompareTo(b.level));

        CheckLevels();
    }

    public void ChooseLevel(int level)
    {
        if (levels[level-1].CanBeUnlocked())
        {
            Debug.Log("Going to Level " + level);
            //SceneManager.LoadScene("Level" + level);

            // Temporary (When the levels are implemented this will be deleted)
            SaveSystem.currentPath = SaveSystem.levelsPath;
            UnlockedLevels unclocked = SaveSystem.Load<UnlockedLevels>();
            unclocked.Add(level);
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
}
