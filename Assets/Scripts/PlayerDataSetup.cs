using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataSetup : MonoBehaviour
{
    public static PlayerDataSetup Instance;
    public string PlayerName;
    public string HighScorePlayer;
    public int PlayerScore;
    private int currentHighScore;
    void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string HighScorePlayer;
        public int PlayerScore;
    }

    public void SaveCurrentData()
    {
        SaveData data = new SaveData();
        if (PlayerName == "")
        {
            if (UIManager.Instance.GetPlayerName() == "Enter name ...")
                PlayerName = "Noname";
            else PlayerName = UIManager.Instance.GetPlayerName();
        }

        if (PlayerScore > currentHighScore)
        {
            data.PlayerName = PlayerName;
            data.PlayerScore = PlayerScore;
            data.HighScorePlayer = PlayerName;
            currentHighScore = PlayerScore;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            currentHighScore = data.PlayerScore;
            PlayerScore = data.PlayerScore;
            HighScorePlayer = data.HighScorePlayer;
        }
        UIManager.Instance.SetHighscore(HighScorePlayer, PlayerScore);
        UIManager.Instance.SetPlayerName(PlayerName);
    }
}
