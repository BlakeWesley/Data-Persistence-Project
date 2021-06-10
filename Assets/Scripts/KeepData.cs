using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public string username;
    public int highScore;
}

public class KeepData : MonoBehaviour
{
    public static KeepData Instance;

    public SaveData dataToSave;

    public string highScoreInfo;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadFromFile();
    }

    public void SaveToFile()
    {
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            dataToSave = JsonUtility.FromJson<SaveData>(json);
        }
        highScoreInfo = "High Score: " + dataToSave.username + ": " + dataToSave.highScore;

    }
}
