using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Horizontal Movement")]
    public float speed;
    public string controlSwitch = "controlSwitch";
    
    Rigidbody2D rb2D;
    public GameObject player;
    
    [Header("Jumping")]
    public int Doublejump;
    public float JumpHeight;
    public float SuperJumpHeight;
    public bool Lag;
    public Groundcheck GC;
    public int RegularGravityScale;
    public Vector2 gravity;


    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        GC = GetComponentInChildren<Groundcheck>();
        Lag = true;
     //   rb2D.useGravity=true; 
     //   Physics2D.gravity = new Vector2(0, 1.0F);
    } 
    void FixedUpdate(){

        if (GC.GroundContact == true) {
            if ((Input.GetKeyDown("a") || Input.GetKeyDown("d")) &&!Input.GetKey(KeyCode.LeftShift)) {
                print("but its the pelvic thrust, that REALLY drives them insane");
                rb2D.velocity = new Vector2(0, 0); //Stannar spelaren innan boosten för att motverka att tröghet i spelarens rörelser ska kvarvara
              //  StartCoroutine(Thrust());
                Lag = false;
            } //Starta Thrust
            if (Input.GetKey("a")) {
                rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            }
            if (Input.GetKey("d")) {
                rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            }
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) {

            StartCoroutine(LagGenerator());
        } //Starta LagGenerator

        else if (Input.GetKeyDown("space") && Doublejump < 2 && Lag == true) {

            if (GC.GroundContact == true) {
                rb2D.gravityScale = RegularGravityScale;
            }
            Jump();
            StartCoroutine(HighJump());

        } //Starta Jump och/eller highjump


    } //Styr spelarkontrollern
   public IEnumerator Thrust() {
        if (Input.GetKeyDown("a")){
            rb2D.velocity = new Vector2(-5, 0);

            print("lets do the timewarp again");
        } // boost vänster
        if (Input.GetKeyDown("d")) {
            rb2D.velocity = new Vector2(5, 0);

        }  //boost höger
        yield return null;
    } //Spelarens första "boost" när man trycker på knappen för rörelse åt sidan 
    private void HorizontalMovement() {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, rb2D.velocity.y);
        
        rb2D.AddForce(movement * speed);
    }  //spelarens normala rörelser i sidled
    private void Jump() {
        if (GC.GroundContact == true) {
            Doublejump = 0;
        } //DoubleJump återställs vid groundcontact
        Doublejump++;
        rb2D.velocity = new Vector2(rb2D.velocity.x, JumpHeight);
        rb2D.AddForce(new Vector2(0,15), ForceMode2D.Impulse);
       // rb2D.AddForce(Vector2.up * JumpHeight);

    }  //Sköter det normala hoppet, även doublejump
    IEnumerator HighJump() {

       
        yield return new WaitForSeconds(0.3f);
        if (Input.GetKey("space")&&Doublejump==1) {
            rb2D.AddForce(new Vector2(0, 250));
            print("Hoppa betch");
            rb2D.gravityScale = 5;

            
              
         //   rb2D.velocity = new Vector2(rb2D.velocity.x, SuperJumpHeight);
         //   rb2D.AddForce(Vector2.up * SuperJumpHeight);
        }

        yield return null;
    } //Sköter det höga hoppet
    IEnumerator LagGenerator() {

        Lag = false;
        yield return new WaitForSeconds(0.3f);
        Lag = true;
        yield return null;

    } //Sköter laggen

}