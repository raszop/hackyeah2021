using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class PlayerData
{
    private static PlayerData instance;
    public static PlayerData Instance { get => instance; set => instance = value; }

    public int Money;

    public int Level;
    public int Experience;
    public int ExpToLevel;

    public int CurrentDay;
    public int CurrentHour;

    public List<string> UnlockedUpgrades;
    public List<Parameter> ParametersData;
}

[System.Serializable]
public class PlayerDataSerializer
{
    [System.NonSerialized]
    private static readonly string saveFileName = "save";
    [System.NonSerialized]
    private static readonly string saveFilePath = Application.persistentDataPath + "/Save/";

    private PlayerData playerData;

    public PlayerData PlayerData { get => playerData; }

    public PlayerDataSerializer()
    {
        playerData = PlayerData.Instance;
    }

    public static void SaveToFile()
    {
        if (!Directory.Exists(saveFilePath))
        {
            Directory.CreateDirectory(saveFilePath);
        }

        PlayerDataSerializer localDataCopy = new PlayerDataSerializer();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = File.Create(saveFilePath + saveFileName);
        formatter.Serialize(fs, localDataCopy);
        fs.Close();
    }

    public static void LoadFromFile()
    {
        PlayerDataSerializer localDataCopy;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = File.Open(saveFilePath + saveFileName, FileMode.Open);
        localDataCopy = (PlayerDataSerializer)formatter.Deserialize(fs);
        fs.Close();

        PlayerData.Instance = localDataCopy.PlayerData;
    }

    public static bool SaveExists()
    {
        return File.Exists(saveFilePath + saveFileName);
    }
}