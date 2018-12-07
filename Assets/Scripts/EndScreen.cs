using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public GameObject endUI;
    public GameObject quitUI;

    float fixDelta;

    private void Start()
    {
        //Destroy(FindObjectOfType<SessionManager>());
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
        fixDelta = Time.fixedDeltaTime;
        Time.fixedDeltaTime = 0f;
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
        Time.fixedDeltaTime = fixDelta;
    }

    public void QuitGame()
    {
        quitUI.GetComponent<QuitMenu>().PreviousScreen(endUI);
        quitUI.SetActive(true);
    }
}