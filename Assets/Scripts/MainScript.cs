using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public GameObject PlayButton, RestartButton, ExitButton, PauseButton;
    bool isPause;

    AudioSource BackgroundSound;
    
    void Start()
    {
        isPause = false;

        BackgroundSound = GetComponent<AudioSource>(); //плучаем доступ к AudioSource
       
    }

    public void Pause()
    {
        if(isPause == true) // если сейчас пауза
        {
            PauseButton.SetActive(true);    // активируем клавишу паузы

            PlayButton.SetActive(false);    // выключаем калаишу play
            RestartButton.SetActive(false); // выключаем калаишу restart
            ExitButton.SetActive(false);    // выключаем калаишу exit

            isPause = false;                // выключаем паузу

            Time.timeScale = 1f;            // включаем время 

            BackgroundSound.Play();         // включаем BackgroundSound
        }
        else
        {
            PauseButton.SetActive(false);   // выключаем клавишу паузы

            PlayButton.SetActive(true);     // включаем калаишу play
            RestartButton.SetActive(true);  // включаем калаишу restart
            ExitButton.SetActive(true);     // включаем калаишу exit

            isPause = true;                 // включаем паузу

            Time.timeScale = 0f;            // stop time

            BackgroundSound.Stop();         // выключаем BackgroundSound
        }
    }

    public void Restart()
    {
        // Перезагрузка сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();// exit game
    }
}
