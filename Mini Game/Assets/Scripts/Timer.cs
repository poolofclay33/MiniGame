using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    public int timeLeft = 60;
    public TMP_Text countDownText;
    public Animator _gameOverAnim;
    public Animator _startGameAnim;
    private int countdownTime = 5;
    public TMP_Text startText;
    public Animator _GO;

    private void Start()
    {
        _startGameAnim.Play("StartGameCountdown");
        InvokeRepeating("LoseTime", 5f, 0f);
        StartCoroutine("StartTime");
    }

    private void Update()
    {
        startText.text = ("" + countdownTime);

        if(countdownTime <= 0)
        {
            StopCoroutine("StartTime");
            _GO.Play("GO!");
            startText.enabled = false;
            //StartCoroutine("LoseTime");
        }

        countDownText.text = ("" + timeLeft);

        if(timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            GameOver();
        }
    }

    IEnumerator StartTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            countdownTime--;
        }
    }

    IEnumerator LoseTime()
    {
        Debug.Log(":(");
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    private void GameOver()
    {
        _gameOverAnim.Play("TimesUp!Anim");
    }
}
