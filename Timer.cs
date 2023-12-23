using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using System;

public class Timer : MonoBehaviour
{
    public int minutes;
    public float seconds;
    private float roundSeconds;
    public TextMeshProUGUI timerTimerText;

    // Цикл обновления составляет примерно 0.01 секунды
    void Update()
    {
        seconds -= Time.deltaTime;

        if (seconds <= 0)
        {
            if (minutes > 0)
            {
                seconds += 59;

                minutes--;
            }
            else
            {
                // Если таймер остановился, перезагружаем текущую сцену
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex);
            }
        }
 
        roundSeconds = Mathf.RoundToInt(seconds);
        timerTimerText.text = minutes + ":" + roundSeconds.ToString();
    }
}
