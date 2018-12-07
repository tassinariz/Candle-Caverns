using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 2f;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GotAllLaterns()) return;

        StartCoroutine(LoadNextLevel());
    }

    private bool GotAllLaterns()
    {
        Lantern[] lanterns = FindObjectsOfType<Lantern>();
        int numofLanterns = lanterns.Length;
        
        for (int i = 0; i < numofLanterns; i++)
        {
            if (!lanterns[i].isLanternOn)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator LoadNextLevel()
    {
        audio.Play();

        Time.timeScale = 0.25f;

        yield return new WaitForSecondsRealtime(levelLoadDelay);

        Time.timeScale = 1f;

        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
} // end class
