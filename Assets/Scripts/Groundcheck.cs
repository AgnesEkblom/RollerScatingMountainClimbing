using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour {
    public bool GroundContact;
    public bool Entered;
    public PlayerMovement PM;
    public Animator A;
	// Use this for initialization
	void Start () {
        
        PM = GetComponentInParent<PlayerMovement>();
        A = GetComponentInParent<Animator>();
    }

    // Update is called once per frame

  /*  public void OnTriggerEnter2D (Collider2D other) {
        
        
        if (other.gameObject.tag=="Dirt") {
            GroundContact = true;
            PM.Doublejump = 0;  
        }
        else if (other.gameObject.tag == "Bounce") {
            GroundContact = true;
        }
        else if (other.gameObject.tag!="Dirt") {
            GroundContact = false;
        }

	}*/
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dirt")
            A.SetBool("isGrounded", true);


    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dirt")
            A.SetBool("isGrounded", true);


    }

    public void OnTriggerExit2D (Collider2D other)
    {
        A.SetBool("isGrounded", false);

    }


 
}
