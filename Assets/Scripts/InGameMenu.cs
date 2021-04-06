using UnityEngine;
using UnityEngine.SceneManagement;

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
