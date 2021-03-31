using UnityEngine;
using UnityEngine.UI;

/*
 * This class is responsible for showing all of the 10 highest stats/scores of that have been achieved and the usernames.
 */
public class ShowStats : MonoBehaviour
{
    private Stats _stats;
    
    private void Awake()
    {
        SaveSystem.currentPath = SaveSystem.statsPath;
        _stats = SaveSystem.Load<Stats>();
        if (_stats == default)
        {
            _stats = new Stats();
            SaveSystem.Save(_stats);
        }
        
        _stats.Add(100, "Someone");
        SaveSystem.Save(_stats);

        SetTexts();
    }

    private void SetTexts()
    {
        // This may return some texts like the title that we do not want to change
        Text[] texts = gameObject.GetComponentsInChildren<Text>();

        int i = 0;
        foreach (Text text in texts)
        {
            // Only the highscore text have font size less than 40. (Prevents us from changing texts like the title that have a big font).
            if (text.fontSize < 40)
            {
                // Format = "Name : Score"
                text.text = (i+1) + ". " + _stats.usernames[i] + " : " + _stats.scores[i];
                i++;
            }
        }
    }
}
