using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject PauseText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            PauseText.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
            PauseText.SetActive(false);
        }
    }
}
