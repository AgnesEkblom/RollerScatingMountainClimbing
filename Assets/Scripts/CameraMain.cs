using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour {
    public int cameraDistance;
    public GameObject player;
    

    public Groundcheck GC;
    public PlayerMovement PM;



    public Vector3 StartPos;
    public Vector3 GoalPos;
    public Transform Startposition;
    public Transform Goalposition;
  
    public float speed;
    private float startTime;
    public float journeyLength;
    public float sortacameravelocity;

    public float fracJourney;
    public float distCovered;




    private void Awake() {
     //   playerYPosition = 0;
        Groundcheck GC = gameObject.GetComponent<Groundcheck>();
        PlayerMovement PM = gameObject.GetComponent<PlayerMovement>();

    }
    void Start () {

        startTime = Time.time;
        journeyLength = Vector3.Distance(Startposition.position, Goalposition.position);
        
    }

    


    void Update() {
  //      Goalposition.transform.position = new Vector3(player.transform.position.x, player.transform.position.x, cameraDistance);
  //      Startposition.transform.position = new Vector3(transform.position.x,transform.position.x, cameraDistance);
        distCovered = (Time.time - startTime) * speed;
        fracJourney = distCovered / journeyLength;
        StartPos = new Vector3(Startposition.position.x, Startposition.position.y, cameraDistance);
        GoalPos = new Vector3(Goalposition.position.x+10, Goalposition.position.y+20, cameraDistance);

        transform.position =  Vector3.Lerp(StartPos, GoalPos, fracJourney);

        sortacameravelocity = (Startposition.transform.position.x - Goalposition.transform.position.x);

    }
}
