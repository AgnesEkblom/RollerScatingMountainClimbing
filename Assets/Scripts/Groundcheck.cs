using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour {
    public bool GroundContact;
    public PlayerMovement PM;
	// Use this for initialization
	void Start () {
        
        PM = GetComponentInParent<PlayerMovement>();

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
            GroundContact = true;

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dirt")
            GroundContact = true;

    }

    public void OnTriggerExit2D (Collider2D other)
    {
        GroundContact = false;
    }
}
