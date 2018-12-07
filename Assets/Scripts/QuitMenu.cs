using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour {

    public GameObject previousScreen;

    public void PreviousScreen(GameObject prev)
    {
        previousScreen = prev;
        
        //Debug.Log("prev");
    }

    private void OnEnable()
    {
        previousScreen.SetActive(false);
        //Debug.Log("enable");
    }

    public void Yes()
    {
        //Debug.Log("Yes");
        Application.Quit();

    }
    public void No()
    {
        //Debug.Log("No");
        gameObject.SetActive(false);
        previousScreen.SetActive(true);
    }
} // end class