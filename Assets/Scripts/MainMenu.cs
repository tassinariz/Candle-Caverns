using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainUI;
    public GameObject quitUI;
    public SessionManager sessionManager;

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        sessionManager.TimerDisabled = false;
        sessionManager.timer = 0;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void QuitGame()
    {
        quitUI.GetComponent<QuitMenu>().PreviousScreen(mainUI);
        quitUI.SetActive(true);
    }
}