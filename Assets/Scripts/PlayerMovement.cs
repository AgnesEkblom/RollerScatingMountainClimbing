using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    [Header("Horizontal Movement")]
    public float speed;
    public int JumpControl;

    public Rigidbody2D rb2D;
    public int maxSpeed;

    [Header("Jumping")]
    public int Doublejump;
    public float JumpHeight;

    public Groundcheck GC;
    public Animator A;



    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        GC = GetComponentInChildren<Groundcheck>();
        A = GetComponent<Animator>();

    }
    void FixedUpdate() {
        //  Physics.gravity = new Vector2(0, -1.0F);
        //   rb2D.mass = 6f;


        if (A.GetBool("isGrounded")==true)
        {

          

      //  if ((Input.GetKey("a") || Input.GetKey("d")))
        if (Input.GetButton("Horizontal"))
        {

            HorizontalMovement();

        }
            Doublejump = 0;//Rör horisontellt

        }



         if (Input.GetKeyDown("space") && Doublejump < 2) {
            print("jump betch");
            Jump();
        } //Starta Jump

    } //Styr spelarkontrollern

    private void HorizontalMovement() {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal*speed, rb2D.velocity.y);
        
        rb2D.AddForce(movement * speed);

        if (rb2D.velocity.magnitude> maxSpeed)
        {
            rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
        }
    }  //spelarens normala rörelser i sidled
    private void Jump() {
 //DoubleJump återställs vid groundcontact
        Doublejump++;

        
  //     rb2D.velocity = new Vector2(rb2D.velocity.x, JumpHeight);
       rb2D.AddForce(new Vector2(0,JumpHeight+((rb2D.velocity.x*rb2D.velocity.x)/30)), ForceMode2D.Impulse);
   

    }  //Sköter det normala hoppet, även doublejump


}