
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class saveSystem 
{
   public static void savePlayer(LevelManager levelManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/LevelManager.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(levelManager);

        formatter.Serialize(stream, data);
        stream.Close();
       
    }

    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/LevelManager.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data=formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file  not found in " + path);
            return null;
        }
    }
}
