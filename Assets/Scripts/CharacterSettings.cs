/*
 * A simple class that will hold all the settings the player will be able to change.
 */
[System.Serializable]
public class CharacterSettings
{
    public float volume;

    public CharacterSettings()
    {
        this.volume = 0f;
    }
    
    public CharacterSettings(float volume)
    {
        this.volume = volume;
    }
}
