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
    public bool Lag;
    public Groundcheck GC;



    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        GC = GetComponentInChildren<Groundcheck>();
        Lag = true;

    } 
    void FixedUpdate(){

        if (GC.GroundContact == true) {
            if ((Input.GetKey("a") || Input.GetKey("d"))) {
                print("but its the slow horizontal movement, that REALLY drives them insane");
                rb2D.velocity = new Vector2(0, 0);//Stannar spelaren innan boosten för att motverka att tröghet i spelarens rörelser ska kvarvara
                HorizontalMovement();

                Lag = false;
            } //Rör horisontellt

        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) {

            StartCoroutine(LagGenerator());
        } //Starta LagGenerator

        else if (Input.GetKeyDown("space") && Doublejump < 2 && Lag == true) {
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
        if (GC.GroundContact == true) {
            Doublejump = 0;
        } //DoubleJump återställs vid groundcontact
        Doublejump++;
        rb2D.velocity = new Vector2(rb2D.velocity.x, JumpHeight);
        rb2D.AddForce(new Vector2(0,15), ForceMode2D.Impulse);
   

    }  //Sköter det normala hoppet, även doublejump

    IEnumerator LagGenerator() {

        Lag = false;
        yield return new WaitForSeconds(0.3f);
        Lag = true;
        yield return null;

    } //Sköter laggen

}