using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMaskLantern : MonoBehaviour {

    [SerializeField] float lightSize = 3f;

    [SerializeField] Transform target;
    [SerializeField] float xAdjust = 5f;
    [SerializeField] float yAdjust = 5f;

    private void Start()
    {
        //adjust position paired sprite mask to position of lantern on the level
        transform.position = new Vector3(target.position.x + xAdjust, target.position.y + yAdjust, target.position.z);
    } // end Start()

    public void TurnOn()
    {
        //if scale is 0
        if (transform.localScale.x < 3)
        {
            //adjust scale to 3
            transform.localScale = new Vector3(lightSize, lightSize, transform.localScale.z);
        }
    } // end TurnOn()
} // end class