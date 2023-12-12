using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Handles saving and loading scores from a file
public class SaveManager
{

    //Creates a save file in a binary format for obfuscation
    public static void SaveScores(SaveData scores)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/high.scores";
        FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, scores);
        stream.Close();
    }

    //Deobfuscates sava data from file and returns it
    public static SaveData LoadScores()
    {
        string filePath = Application.persistentDataPath + "/high.scores";

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
