using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Debug.Log(this.getPath());
        FileStream stream = new FileStream(this.getPath(), FileMode.Create); // stream of data contained in a file
        PlayerData playerData = new PlayerData(); // instantiating the object that will contain the data that will be stored

        formatter.Serialize(stream, playerData); // write info
        stream.Close();
    }

    public PlayerData Load()
    {
        if (ExistsData()) // check if file exists
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(this.getPath(), FileMode.Open); // changed to .Open because we want to open an existing file

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + this.getPath());
            return null;
        }
    }

    public string getPath()
    {
        string path = Application.persistentDataPath + "/player.scinese"; // persistentDataPath is a built-in funct from unity, it gives a path to a specific folder in the OS that you're sure that is not going to change unexpectedly 
        return path;
}
public bool ExistsData()
    {
        if (File.Exists(this.getPath())) {
            return true;
        }
        return false;
    }
}
