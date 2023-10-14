using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveGameState();
        LoadGameState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveGameState()
    {
        SaveDataModel model = new SaveDataModel();
        model.playerName = "Example";
        model.currentHighScore = 0;
        model.currentPosition = transform.position;

        string json = JsonUtility.ToJson(model);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log("Writing file to: " + Application.persistentDataPath); // Sends to "C:\Users\<user>\AppData\LocalLow\<company name>".
    }
    
    void LoadGameState()
    {
        SaveDataModel model = JsonUtility.FromJson<SaveDataModel>(File.ReadAllText(Application.persistentDataPath + "/save.json"));
        Debug.Log(model.playerName);
        Debug.Log(model.currentHighScore);
        Debug.Log(model.currentPosition);
    }
}

[Serializable]
public class SaveDataModel
{
    public string playerName;
    public int currentHighScore;
    public Vector3 currentPosition;
}