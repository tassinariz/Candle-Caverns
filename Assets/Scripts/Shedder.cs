using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shedder : MonoBehaviour {

    public AudioClip drip;
    AudioSource audioSrc;
    Random Rand = new Random();
    float pitchrand;
    private bool bDrip;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pitchrand = Random.Range(0.5f, 1.5f);
        audioSrc.pitch = pitchrand;
        audioSrc.PlayOneShot(drip);

        Destroy(collision.gameObject);
    }
} // end class