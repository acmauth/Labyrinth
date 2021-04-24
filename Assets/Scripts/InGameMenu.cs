using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script represents the In-Game Menu and basically holds the functions that are going to be used by the
 * buttons in the menu.
 *
 * Αυτό το script αναπαραστά το In-Game Menu και κρατά τις συναρτήσεις που θα χρησιμοποιηθούν από τα buttons στο
 * μενού.
 */
public class InGameMenu : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        if (level == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
        
        SceneManager.LoadScene("Level" + level);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
