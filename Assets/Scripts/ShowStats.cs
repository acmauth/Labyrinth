using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class is responsible for showing all of the 10 highest stats/scores
 * of that have been achieved and the usernames.
 *
 * Η κλάση είναι υπεύθυνη για να εμφανίζει τα 10 μεγαλύτερα score των παικτών μαζί με τα username.
 */
public class ShowStats : MonoBehaviour
{
    private Stats _stats;

    private void OnEnable()
    {
        SaveSystem.currentPath = SaveSystem.statsPath;
        _stats = SaveSystem.Load<Stats>();
        if (_stats == default || _stats == null)
        {
            _stats = new Stats();
            SaveSystem.Save(_stats);
        }

        SetTexts();
    }
    
    private void SetTexts()
    {
        // This may return some texts like the title that we do not want to change
        Text[] texts = gameObject.GetComponentsInChildren<Text>();

        int i = 0;
        foreach (var text in texts)
        {
            if (text.CompareTag("Score"))
            {
                text.text = (i + 1) + ". " + _stats.stats[i].username + " : " +
                            Math.Floor(_stats.stats[i].avgTime) +
                            " sec : " + Math.Floor(_stats.stats[i].score);
                i++;
            }
        }
    }
}
