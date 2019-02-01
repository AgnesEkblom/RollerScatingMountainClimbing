using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Horizontal Movement")]
    public float speed;


    public Rigidbody2D rb2D;


    [Header("Jumping")]
    public int Doublejump;
    public float JumpHeight;

    public Groundcheck GC;



    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        GC = GetComponentInChildren<Groundcheck>();


    }
    void FixedUpdate() {
        //  Physics.gravity = new Vector2(0, -1.0F);
        //   rb2D.mass = 6f;


        if (GC.GroundContact == true)
        {

        

        if ((Input.GetKey("a") || Input.GetKey("d")))
        {
            //print("but its the slow horizontal movement, that REALLY drives them insane");
            //  rb2D.velocity = new Vector2(0, 0);//Stannar spelaren innan boosten för att motverka att tröghet i spelarens rörelser ska kvarvara
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
    }  //spelarens normala rörelser i sidled
    private void Jump() {
 //DoubleJump återställs vid groundcontact
        Doublejump++;

        
  //     rb2D.velocity = new Vector2(rb2D.velocity.x, JumpHeight);
       rb2D.AddRelativeForce(new Vector2(0,JumpHeight), ForceMode2D.Impulse);
   

    }  //Sköter det normala hoppet, även doublejump


}