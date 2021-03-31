using UnityEngine;
using UnityEngine.UI;

/*
 * A script that contains functions ready to be used by the event system handler
 * whenever some buttons are pressed.
 *
 * Ένα script που περιέχει κάποιες συναρτήσεις έτοιμες να χρησιμοποιηθούν όταν κάποιο από τα κουμπιά πατιούνται.
 */
public class Menu : MonoBehaviour
{
    public Slider[] volumeSliders; // All of the sliders in the Main Menu scene
    
    private float _volume;
    
    // Start is called before the first frame update
    void Start()
    {
        _volume = 0f;
    }

    // Updates the volume property everytime the value in the active slider is changed.
    public void UpdateVolume()
    {
        foreach (Slider slider in volumeSliders)
        {
            if (slider.isActiveAndEnabled) _volume = slider.value;
        }

        foreach (Slider slider in volumeSliders)
        {
            slider.value = _volume;
        }

        // Get the save settings from the file and change the volume
        SaveSystem.currentPath = SaveSystem.settingsPath;
        CharacterSettings settings = SaveSystem.Load<CharacterSettings>();
        if (settings == default)
        {
            settings = new CharacterSettings(_volume);
        }
        else
        {
            settings.volume = _volume;
        }
        //SaveSystem.Save(settings);
    }

    // Quits the game when the appropriate button is pressed
    public void Quit()
    {
        Application.Quit();
    }
}
