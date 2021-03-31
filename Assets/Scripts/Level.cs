using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Button button;
    public int level;
    public List<int> parentLevels;
    private List<int> unlockedLevels;
    private bool canBeUnlocked; 

    // Start is called before the first frame update
    void Start()
    {
        if (parentLevels == null)
        {
            parentLevels = new List<int>();
            parentLevels.Add(level - 1);
        }

        if (button == null)
        {
            button = gameObject.GetComponent<Button>();
        }

        SaveSystem.currentPath = SaveSystem.levelsPath;
        UnlockedLevels temp = SaveSystem.Load<UnlockedLevels>();
        unlockedLevels = temp.unlocked;
    }

    public bool CanBeUnlocked()
    {
        return canBeUnlocked;
    }

    public void CheckUnlocked()
    {
        if (unlockedLevels == null)
        {
            SaveSystem.currentPath = SaveSystem.levelsPath;
            UnlockedLevels temp = SaveSystem.Load<UnlockedLevels>();
            unlockedLevels = temp.unlocked;
        }
        
        canBeUnlocked = true;
        
        foreach (int parent in parentLevels)
        {
            if (!unlockedLevels.Contains(parent))
            {
                canBeUnlocked = false;
            }
        }

        if (!canBeUnlocked)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
