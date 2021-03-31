using System.IO;
using UnityEngine;

public class CreateStarterFiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(SaveSystem.settingsPath))
        {
            CharacterSettings settings = new CharacterSettings();
            SaveSystem.currentPath = SaveSystem.settingsPath;
            SaveSystem.Save(settings);
            
            Debug.Log("Settings file created.");
        }
        
        if (!File.Exists(SaveSystem.statsPath))
        {
            Stats stats = new Stats();
            SaveSystem.currentPath = SaveSystem.statsPath;
            SaveSystem.Save(stats);
            
            Debug.Log("Stats file created.");
        }

        if (!File.Exists(SaveSystem.levelsPath))
        {
            UnlockedLevels unlocked = new UnlockedLevels();
            SaveSystem.currentPath = SaveSystem.levelsPath;
            SaveSystem.Save(unlocked);
            
            Debug.Log("Levels file created.");
        }
    }

    public void DeleteFiles()
    {
        SaveSystem.ClearAllPathFiles();
    }
}
