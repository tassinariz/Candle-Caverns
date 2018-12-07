using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    bool isPaused = false;
    public GameObject pauseUI;
    public GameObject quitUI;

    float fixDelta;

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	} // end Update()

    public void ResumeGame()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixDelta;
    }// end ResumeGame()

    public void PauseGame()
    {
        isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        fixDelta = Time.fixedDeltaTime;
        Time.fixedDeltaTime = 0f;
    }// end PauseGame()

    public void LoadMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Destroy(FindObjectOfType<SessionManager>());
    }
    public void QuitGame()
    {
        quitUI.GetComponent<QuitMenu>().PreviousScreen(pauseUI);
        quitUI.SetActive(true);
    }
} // end class