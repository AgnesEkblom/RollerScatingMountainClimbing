using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [Header("Groundstate")]
    public float speed;


    public Rigidbody2D rb2D;


    [Header("Airstate")]
    public int Doublejump;
    public float JumpHeight;
    public float AirCTRL;
    private Groundcheck GC;
    private Animator A;

    public float maxHorizontalSpeed;
    public float maxVerticalSpeed;
    public float currentHorizontalSpeed;
    public float currentVerticalSpeed;
    public float HorizontalSpeedAddition;
    public float AccelerationBonus;
    public bool Speedyboi;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        GC = GetComponentInChildren<Groundcheck>();
        A = GetComponent<Animator>();
        Speedyboi = true;


    }
    void FixedUpdate()
    {




        LimitHorizontal();
        LimitVertical();
        float movementX = Input.GetAxis("Horizontal");

        if (A.GetBool("isGrounded") == true)
        {
            Doublejump = 0;
            if (Mathf.Abs(movementX) > 0.1)
            {
                Vector2 movement = new Vector2(movementX*(AccelerationBonus+1), 0);
                rb2D.AddForce(movement * speed);
            }

//Rör horisontellt

        }
        //  Physics.gravity = new Vector2(0, -1.0F);
        //   rb2D.mass = 6f;
        // VelocityValue = (rb2D.velocity.x  * rb2D.velocity.x);

        if ((Input.GetButtonDown("Jump")&& A.GetBool("isGrounded") == true))
        {


            Jump();

           
            Doublejump++;
            // 

        } //Starta Jump






        if (A.GetBool("isGrounded") == false)
        {
            float moveHorizontalAir = Input.GetAxis("Horizontal");

            rb2D.AddRelativeForce(new Vector2(moveHorizontalAir * AirCTRL, 0), ForceMode2D.Impulse);

        }
        if (Speedyboi==true)
        StartCoroutine(Acceleration());
    } //Styr spelarkontrollern

    private void LimitHorizontal()
    {
        currentHorizontalSpeed = rb2D.velocity.x;

        if (currentHorizontalSpeed > maxHorizontalSpeed) //Ifall din hastighet är STÖRRE än MAX
        {
            rb2D.velocity = new Vector2(maxHorizontalSpeed, rb2D.velocity.y);
        }
        else if (currentHorizontalSpeed < -maxHorizontalSpeed) //Ifall din hastighet är MINDRE än MAX * -1 
        {
            rb2D.velocity = new Vector2(-maxHorizontalSpeed, rb2D.velocity.y);
        }
    }
    private void LimitVertical()
    {
        currentVerticalSpeed = rb2D.velocity.y;

        if (currentVerticalSpeed > maxVerticalSpeed) //Ifall din hastighet är STÖRRE än MAX
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, maxVerticalSpeed);
        }
        else if (currentVerticalSpeed < -maxVerticalSpeed) //Ifall din hastighet är MINDRE än MAX * -1 
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -maxVerticalSpeed);
        }
    }
    public void Jump()
    {
        Vector2 Jumpspeed = new Vector2(0, JumpHeight + (Mathf.Abs(rb2D.velocity.x * HorizontalSpeedAddition)));
        rb2D.AddForce((Jumpspeed), ForceMode2D.Impulse);
    }

    public IEnumerator Acceleration()
    {
        Speedyboi = false;
        float movementX = Input.GetAxis("Horizontal");


        if (Mathf.Abs(movementX) > 0.1)
        {
            yield return new WaitForSeconds(1);
            AccelerationBonus=AccelerationBonus+0.1f;
        }
        else AccelerationBonus = 0;
        Speedyboi = true;
    }

}