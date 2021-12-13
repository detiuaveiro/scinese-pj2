using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.scinese"; // persistentDataPath is a built-in funct from unity, it gives a path to a specific folder in the OS that you're sure that is not going to change unexpectedly
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create); // stream of data contained in a file
        PlayerData playerData = new PlayerData(); // instantiating the object that will contain the data that will be stored

        formatter.Serialize(stream, playerData); // write info
        stream.Close();
    }

    public PlayerData Load()
    {
        string path = Application.persistentDataPath + "/player.scinese"; // persistentDataPath is a built-in funct from unity, it gives a path to a specific folder in the OS that you're sure that is not going to change unexpectedly
        if (File.Exists(path)) // check if file exists
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); // changed to .Open because we want to open an existing file

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    
    
    
    }
}
