using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text highScore;
    public Text currentPlayer;
    public TMP_InputField inputField;

    private void Awake()
    {
        Instance = this;
    }

    public void SetHighscore(string name, int score)
    {
        if (score > 0)
            highScore.text = "Best Score : " + name + " : " + score.ToString();
        else highScore.text = "";
    }

    public void SetPlayerName(string name)
    {
        if (currentPlayer != null)
            currentPlayer.text = name;
    }

    public string GetPlayerName()
    {
        return inputField.text;
    }
}
