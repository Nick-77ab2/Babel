using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inGameManagement : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;
    public GameObject GameOverUI;
    public GameObject PauseUI;
    public Button restartButton;
    public Button resumeButton;
    public Button mainMenuButton;
    public Button quitButton;

    private float playerHP;
    private float prevHealth;
    private float prevAttack;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        
        Button resBtn = restartButton.GetComponent<Button>();
        resBtn.onClick.AddListener(ResetGame);
        Button resumeBtn = resumeButton.GetComponent<Button>();
        resumeBtn.onClick.AddListener(ResumeGameUI);
        Button mainBtn = mainMenuButton.GetComponent<Button>();
        mainBtn.onClick.AddListener(MainMenu);
        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(MainMenu);

        prevHealth = PlayerHealth.health;
        prevAttack = PlayerAttack.attackPower;
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = PlayerHealth.health;

        if (playerHP <= 0)
        {
            PauseGame();
            GameOverUI.SetActive(true);
        }





        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                PauseGame();
                PauseUI.SetActive(true);
            }
            else if (isPaused)
            {
                isPaused = false;
                PauseUI.SetActive(false);
                ResumeGame();
            }
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        PlayerHealth.health = prevHealth;
        PlayerAttack.attackPower = prevAttack;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ResumeGameUI()
    {
        ResumeGame();
        PauseUI.SetActive(false);
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
