using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    public int timeLeft = 5;
    public TMP_Text countDownText;

    private void Start()
    {
        StartCoroutine("LoseTime");
    }

    private void Update()
    {
        countDownText.text = ("" + timeLeft);

        if(timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countDownText.text = "Times Up!";
        }
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
