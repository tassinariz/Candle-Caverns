using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour {

    public bool isLanternOn = false;

    // Cached Component References
    Animator myAnimator;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

    } // end Start ()

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLanternOn) return;

        isLanternOn = true;
        myAnimator.SetBool("bolOn", true);
        gameObject.GetComponentInChildren<SMaskLantern>().TurnOn();
        audio.Play();

        FindObjectOfType<SessionManager>().DecrementLanternCount();
    }
} // end class