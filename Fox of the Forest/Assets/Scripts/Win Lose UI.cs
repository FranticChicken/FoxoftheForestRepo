using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
    public PlayerHealth playerHeealScript;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public PlayerController playerConScript;
    public Button quitButton;
    public Button restartButton;
    public Button quitButton2;
    public Button restartButton2;

    public GameObject happyStand;
    public GameObject crouchNeutral;
    public GameObject crouchSad;
    public GameObject standNeutral;
    public GameObject standSad;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(OnQuitButtonClick);
        //quitButton2.onClick.AddListener(OnQuitButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        //restartButton2.onClick.AddListener(OnRestartButtonClick);
    }

    void OnQuitButtonClick()
    {
        Application.Quit();
    }

    void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("restart game");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHeealScript.gameOver == true)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if(playerConScript.gameWon == true)
        {
            happyStand.SetActive(true);
            crouchNeutral.SetActive(false);
            crouchSad.SetActive(false);
            standNeutral.SetActive(false);
            standSad.SetActive(false);
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
