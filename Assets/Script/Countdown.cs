using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text countdownText; // Use TMP for better UI
    // public float countdownTime = 10f;
    private int countdownId;

    public void SetCountdown(float countdownTime)
    {
        countdownId = CountdownManager.Instance.StartCountdown(
            countdownTime,
            UpdateCountdownText,
            () =>
            {
                CountdownManager.Instance.StopCountdown(countdownId);
                CountdownManager.Instance.DespawnOjb(transform);
            }

        );
    }

    private void UpdateCountdownText(int timeLeft)
    {
        countdownText.text = timeLeft.ToString();
    }


}
