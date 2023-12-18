using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    //[SerializeField] public TextMeshProUGUI scoreText;
    //public float Player_Score = 0;

    public bool GameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        //Player_Controller IsDead = gameObject.GetComponent<Player_Controller>(); //call function from another script
    }

    /*
    public void PlayerScore()
    {
        if (GameEnd == false)
        {
            Debug.Log("+1");
            Player_Score++;
            scoreText.text = "Score: " + Player_Score.ToString();
        }
            return;
    } */

    private void Update()
    {
        if (GameEnd)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    public void GameEnding()
    {
        GameEnd = true;
        Debug.Log("1");

    }
}
