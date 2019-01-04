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

    public float smoothTimeX;
    public float smoothTimeY;
    private float velocity = 0.0F;
    
    public int LastGroundCheck;

    public Groundcheck GC;
    private float SortaFollowPlayer;

    private void Awake() {
        playerYPosition = 0;
    }
    void Start () {
      //  offset = transform.position - player.transform.position;
        
	}

    void LateUpdate() {
        playerFollower = new Vector2(0, 0);
        SortaFollowPlayer =player.transform.position.x;

       // float transformpositiony = transformpositiony + LastGroundCheck;

        float newPositionX = Mathf.SmoothDamp(transform.position.x, SortaFollowPlayer+5, ref velocity, smoothTimeX);
        float newPositionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity, smoothTimeY);
        transform.position = new Vector3(newPositionX, player.transform.position.y, cameraDistance);


        



    }
}
