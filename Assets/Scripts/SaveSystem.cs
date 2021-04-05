using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/*
 * This class implements a basic save system. Everything you want to save or load will be saved or loaded
 * from the currentPath file. Warning!!! : Make sure you switch the currentPath to the path you want.
 *
 * Η κλάση υλοποιεί ένα σύστημα αποθήκευσης. Οτιδήποτε θέλεις να αποθηκεύσεις ή να φορτώσεις μπορείς να το κάνεις
 * από το currentPath αρχείο. ΠΡΟΣΟΧΗ!!! : Φροντίστε να αλλάξετε το currentPath στο path που θέλετε.
 */
public static class SaveSystem
{
    public static string currentPath = null; // The current path 
    public static readonly string settingsPath = Application.persistentDataPath + "player.settings";
    public static readonly string statsPath = Application.persistentDataPath + "player.stats";

    // Saves a certain data type at the current path location
    public static void Save<T>(T data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        FileStream stream = new FileStream(currentPath, FileMode.Create);

        formatter.Serialize(stream, data);
        
        stream.Close();
    }

    // Loads a certain data type of the current path location. If the file does not yet exists it returns null/default
    public static T Load<T>()
    {
        if (File.Exists(currentPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            FileStream stream = new FileStream(currentPath, FileMode.Open);
            
            T data = (T)formatter.Deserialize(stream);
            stream.Close();
    
            return data;
        }
        else
        {
            //Debug.LogError("Save file not found in " + currentPath);
            return default;
        }
    }

    // Deletes all the files we have created for the save system. USE WITH CAUTION!!!
    public static void ClearAllPathFiles()
    {
        File.Delete(settingsPath);
        File.Delete(statsPath);
    }
}
