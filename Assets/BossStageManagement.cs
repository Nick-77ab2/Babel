using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStageManagement : MonoBehaviour
{
    public Button winMainMenuButton;
    public GameObject WinUI;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        Button winBtn = winMainMenuButton.GetComponent<Button>();
        winBtn.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            PauseGame();
            WinUI.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
