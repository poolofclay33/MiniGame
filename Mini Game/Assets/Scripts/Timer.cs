using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {
    
    public int timeLeft = 10;
    public TMP_Text countDownText;
    public Animator _gameOverAnim;
    public Animator _startGameAnim;
    private int countdownTime = 5;
    public TMP_Text startText;
    public Animator _GO;

    private void Start()
    {
        _startGameAnim.Play("StartGameCountdown");
        StartCoroutine("StartTime");
    }

    IEnumerator StartTime()
    {
        while (countdownTime >= 1)
        {
            yield return new WaitForSeconds(1);
            startText.text = ("" + --countdownTime);
        }

        startText.enabled = false;
        _GO.Play("GO!");

        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            countDownText.text = ("" + --timeLeft);
        }

        GameOver();
    }

    private void GameOver()
    {
        _gameOverAnim.Play("TimesUp!Anim");
    }
}
