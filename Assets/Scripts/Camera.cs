using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public int cameraDistance;
    public GameObject player;
    public GameObject PlatformLower;
    private Vector3 offset;
    private Vector2 playerFollower;
    public float playerYPosition;
    public float XOffset;
    public float YOffset;

    public float smoothTimeX;
    public float smoothTimeY;
    public float velocity;
    
    public int LastGroundCheck;

    public Groundcheck GC;
    public PlayerMovement PM;
    
    private float SortaFollowPlayer;

    private void Awake() {
     //   playerYPosition = 0;
        Groundcheck GC = gameObject.GetComponent<Groundcheck>();
        PlayerMovement PM = gameObject.GetComponent<PlayerMovement>();
    }
    void Start () {
        //  offset = transform.position - player.transform.position;
        // transform.position

    }

    void Update() {
       // playerFollower = new Vector2(0, 0);
     /*   SortaFollowPlayer = player.transform.position.x;
        float newPositionX = Mathf.SmoothDamp(transform.position.x, SortaFollowPlayer, ref velocity, smoothTimeX);
        float newPositionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + YOffset, ref velocity, smoothTimeY);
        transform.position = new Vector3(newPositionX, transform.position.y, cameraDistance);
        // float transformpositiony = transformpositiony + LastGroundCheck;
        if (GC.GroundContact == true) { 

        //   float newPositionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity, smoothTimeY);
        
    }
    
        else if (GC.GroundContact == false) {
            
            transform.position= new Vector3 (player.transform.position.x, player.transform.position.y, cameraDistance);
            
           // transform.position = new Vector3 (player.transform.position.x, newPositionY, cameraDistance);
        }
        */

        if (GC.GroundContact==true&&PM.rb2D.velocity.y<0.1) {

            playerYPosition= player.transform.position.y;

        }

 
            float newPositionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x+XOffset, ref velocity, smoothTimeX);
            transform.position = new Vector3(newPositionX, playerYPosition+YOffset, cameraDistance);


    }
}
