using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMaskPlayer : MonoBehaviour {   

    [SerializeField] Transform target;
    [SerializeField] int followSpeed = 20;
    [SerializeField] float xAdjust = 5f;
    [SerializeField] float yAdjust = 5f;

    [SerializeField] float scale = 3f;

    private void Start()
    {
        transform.localScale = new Vector3(scale, scale, 1f);
        transform.position = new Vector3(target.position.x + xAdjust, target.position.y + yAdjust, target.position.z);
    } // end Start()

    // Update is called once per frame
    void Update () {
        
        Vector3 hello = new Vector3(target.position.x + xAdjust, target.position.y + yAdjust, target.position.z); 
        transform.position = Vector3.MoveTowards(transform.position, hello, followSpeed * Time.deltaTime);

	} // end Update()
} // end class