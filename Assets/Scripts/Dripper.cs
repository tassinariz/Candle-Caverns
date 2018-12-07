using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripper : MonoBehaviour {

    [SerializeField] GameObject dropPrefab;
    [SerializeField] float fallSpeed = 26f;
    [SerializeField] float dripTime = 1f;

    float timer;

    // Use this for initialization
    void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        TimetoDrip();
	}

    private void TimetoDrip()
    {
        timer += Time.deltaTime;

        if (timer > dripTime)
        {
            // create drop
            GameObject drop = Instantiate(dropPrefab, transform.position, dropPrefab.transform.localRotation) as GameObject;

            Rigidbody2D rigid = drop.GetComponent<Rigidbody2D>();

            rigid.velocity = new Vector2(rigid.velocity.y, -fallSpeed);

            timer = 0;
        }
    } // end TimetoDrip()
} // end class