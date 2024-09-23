using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class SaveLoadBinary
{
    public static SaveLoadBinary instance;
    public int SaveLoadVersion = 0;
    public int activeWeaponIndex = 0;
    
    //todo money, level, etc.
    
    public static void SaveGame()
    {
        string path = Application.persistentDataPath + "/SaveLoadBinary.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate);
        bf.Serialize(file, instance);
        file.Close();
    }

    public static void LoadGame()
    {
        string path = Application.persistentDataPath + "/SaveLoadBinary.dat";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            SaveLoadBinary data = (SaveLoadBinary) bf.Deserialize(file);
            file.Close();
            instance = data;
        }
        else
        {
            instance = new SaveLoadBinary();
            SaveGame();
        }
    }
}
