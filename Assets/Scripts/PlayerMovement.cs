using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    [Header("Groundstate")]
    public float speed;
    public int maxSpeed;

    public Rigidbody2D rb2D;
    

    [Header("Airstate")]
    public int Doublejump;
    public float JumpHeight;
    public float AirCTRL;
    private Groundcheck GC;
    private Animator A;





    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        GC = GetComponentInChildren<Groundcheck>();
        A = GetComponent<Animator>();

    }
    void FixedUpdate() {
        //  Physics.gravity = new Vector2(0, -1.0F);
        //   rb2D.mass = 6f;
       // VelocityValue = (rb2D.velocity.x  * rb2D.velocity.x);

        if (A.GetBool("isGrounded")==true)
        {

          

      //  if ((Input.GetKey("a") || Input.GetKey("d")))
        if (Input.GetButton("Horizontal"))
        {

                float moveHorizontal = Input.GetAxis("Horizontal");
                Vector2 movement = new Vector2(moveHorizontal * speed, rb2D.velocity.y);

                rb2D.AddForce(movement);

                if (rb2D.velocity.magnitude > maxSpeed)
                {
                    rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
                }

            }
            Doublejump = 0;//Rör horisontellt

        }



         if (Input.GetButtonDown("Jump") && Doublejump < 2) {

           
            rb2D.AddForce(new Vector2(0, JumpHeight + ((rb2D.velocity.x * rb2D.velocity.x) / 150)), ForceMode2D.Impulse);
            Doublejump++;



        } //Starta Jump

     /*   if (A.GetBool("isGrounded") == false && Input.GetButton("Horizontal"))
        {
            float moveHorizontalAir = Input.GetAxis("Horizontal");

            rb2D.AddForce(new Vector2(moveHorizontalAir * speed*AirCTRL,0), ForceMode2D. Impulse);
        }*/


    } //Styr spelarkontrollern




}