using System.IO;
using UnityEngine;

/*
 * This class creates all of the custom files we need for the game (example: Settings, Stats...).
 * Αυτή η κλάση φτιάχνει όλα τα αρχεία που χρειαζόμαστε για το παιχνίδι (παράδειγμα: Settings, Stats...).
 *
 * Note: The files will be created at the start of the game and only if they are not yet created.
 * Σημείωση: Τα αρχεία θα δημιουργηθούν στην αρχή του παιχνιδιού και μόνο αν δεν έχουν ήδη δημιουργηθεί.
 */
public class CreateStarterFiles : MonoBehaviour
{
    void Awake()
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
    }

    /*
     * When you hold left or right control and then press Delete then the DeleteFiles method is called.
     */
    private void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) &&
            Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteFiles();
        }
    }

    /*
     * This function is only called for debugging purposes from the CAUTION button at the Main Menu and it delete all of the custom files.
     * When you test the game in the editor and you want to delete the files so that you can create them again from the start you just hit the
     * CAUTION button and then when you test it again the files will be created again.
     *
     * Αυτή η συνάρτηση καλείται μόνο για λόγους debugging από το CAUTION κουμπί στο αρχικό μενού και διαγράφει όλα τα custom αρχεία.
     * Όταν τεστάρεις το παιχνίδι στον editor και θες να διαγράψεις τα αρχεία ώστε να τα ξαναφτιάξεις από την αρχή απλά πατάς το CAUTION κουμπί
     * και μετά όταν το ξανατεστάρεις θα δημιουργήσει ξανά τα αρχεία.
     */
    private void DeleteFiles()
    {
        SaveSystem.ClearAllPathFiles();
        Debug.Log("Deleted");
    }
}
