using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    // Configuration
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float jumpTimer;
    [SerializeField] Vector2 deathFlick = new Vector2(2f, 2f);

    public AudioClip jumpSound, dieSound;

    // Cached Component References
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    CircleCollider2D myCircleCollider;
    AudioSource audioSrc;

    // States
    bool isAlive = true;

	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();

        audioSrc = GetComponent<AudioSource>();
    } // end Start ()
	
	// Update is called once per frame
	void Update () {

        // if dead disable controls
        if (!isAlive) return;

        FlipSprite();
        Move();
        Jump();
        Die();

    } // end Update ()
    
    private void FlipSprite()
    {
        // find if player is moving
        bool hasHorizontalSpeed = Math.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        // if the player is moving
        if (hasHorizontalSpeed)
        {
            // make the sign of the scale of the player sprite the same as the sign of its velocity
            // if running right, its positive, the sprite stays the same, if left, its negative and flips sprite left
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    } // end FlipSprite ()

    private void Jump()
    {
        // if not touching the ground skip jump logic
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) &&
            !myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        // check if jump button is pressed down
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jump = new Vector2(0f, jumpSpeed);

            myRigidBody.velocity += jump;

            audioSrc.PlayOneShot(jumpSound);
        }
    } // end Jump ()

    private void Move()
    {
        // get horizontal input
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // returns -1 to 1
        // assign to velocity
        myRigidBody.velocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);


        // if the player is moving trigger move animation
        bool hasHorizontalSpeed = Math.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("bolMoving", hasHorizontalSpeed);
    } // end Move ()

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Water", "Dripper")))
        {
            isAlive = false;

            // trigger Die Animation
            myAnimator.SetBool("bolAlive", false);
            myRigidBody.velocity = deathFlick;

            //prevents sliding upon death and provides better appearance when dead
            myFeetCollider.enabled = false;

            audioSrc.PlayOneShot(dieSound);

            //call manager process method
            FindObjectOfType<SessionManager>().ProcessDeath();
        }
    } // end Die ()
} // end class