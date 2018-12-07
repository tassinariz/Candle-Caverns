using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Configuration
    [SerializeField] float moveSpeed = 5f;

    // Cached Component References
    Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

	} // end Start ()
	
	// Update is called once per frame
	void Update () {
        if (isFacingLeft())
        {
            // move left
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            // move right
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        

	} //end Update ()

    bool isFacingLeft()
    {
        // if positive then facing left
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // assign sign of velocity to scale when no more ground
        transform.localScale = new Vector2((Mathf.Sign(myRigidBody.velocity.x)), 1f);
    } // end OnTriggerExit2D

} // end class
