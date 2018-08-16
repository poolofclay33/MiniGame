using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {

    [SyncVar(hook = "OnScoreChanged")]
    public int score;
    [SyncVar]
    public Color color;
    [SyncVar]
    public string playerName;
    [SyncVar(hook = "OnLifeChanged")]
    public int lifeCount;

    void OnScoreChanged(int newValue)
    {
        score = newValue;
        UpdateScoreLifeText();
    }

    void OnLifeChanged(int newValue)
    {
        lifeCount = newValue;
        UpdateScoreLifeText();
    }

    void UpdateScoreLifeText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = playerName + "\nSCORE : " + score + "\nLIFE : ";
            for (int i = 1; i <= lifeCount; ++i)
                _scoreText.text += "X";
        }
    }


}
