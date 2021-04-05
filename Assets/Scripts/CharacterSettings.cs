/*
 * A simple class that will hold all the settings the player will be able to change.
 * Μία απλή κλάση η οποία θα κρατάει τα στοιχεία για τα settings του παίκτη.
 */
[System.Serializable]
public class CharacterSettings
{
    public float volume;

    public CharacterSettings()
    {
        this.volume = 100f;
    }
    
    public CharacterSettings(float volume)
    {
        this.volume = volume;
    }
}
