using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SessionManager : MonoBehaviour {

    [SerializeField] float playerDeathDelay = 2f;

    [SerializeField] Text timerText;
    
    [SerializeField] Text lanternText;

    public AudioClip allLanternsSound;
    AudioSource audioSrc;

    public int numLanterns;
    public bool TimerDisabled;
    public float timeBuffer;
    public float timer;
    public float allTimes;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        timerText.text = "";
        if(numLanterns != 0)
        {
            lanternText.text = numLanterns.ToString();
        }

        timeBuffer = Time.time;
    }

    private void Update()
    {
        if (!TimerDisabled)
        {
            timer = Time.time - timeBuffer;

            string min = ((int)timer / 60).ToString();
            string sec = ((int)timer % 60).ToString("##");
            if ((int)timer % 60 < 10)
            {
                sec = 0 + ((int)timer % 60).ToString("##");
            }

            timerText.text = "Time: " + min + ":" + sec;
        }
    }

    private void Awake()
    {
        int numSessionManager = FindObjectsOfType<SessionManager>().Length;

        if (numSessionManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    } // end Awake();

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!TimerDisabled)
        {
            allTimes += timer;
            timer = 0;
        }
        
        
        Debug.Log(scene.buildIndex);

        if (scene.buildIndex == 0)
        {
            //Destroy(gameObject);

            GameObject.FindObjectsOfType<SessionManager>();
        }

        if (!TimerDisabled)
        {
            ResetLanternCount();
        }
        
    }

    public void ProcessDeath()
    {
        StartCoroutine(TakeLife());
    } // end ProcessDeath()

    public IEnumerator TakeLife()
    {
        yield return new WaitForSecondsRealtime(playerDeathDelay);

        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    } // end TakeLife()

    public void DecrementLanternCount()
    {
        //decrement count and display
        numLanterns--;
        lanternText.text = numLanterns.ToString();

        if (numLanterns == 0)
        {
            audioSrc.PlayOneShot(allLanternsSound, 1);
        }
    } // end DecrementLanternCount()

    public void ResetLanternCount()
    {
        numLanterns = FindObjectsOfType<Lantern>().Length;
        lanternText.text = numLanterns.ToString();
    }
} // end class