using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour {
    public GameObject player;
    public int Levelname;
    public Transform startLocation;
    public Vector2 startPosition;
    public PlayerStats PS;
    public Rigidbody2D Rb2D;
    public PlayerMovement PM;
    public int Health;

    // Use this for initialization
    public void Awake() {
        Health = 5;
        Levelname = 1;
    }
    void Start () {
        PM = GetComponent<PlayerMovement>();
        PS= GetComponentInChildren<PlayerStats>();
        Rb2D = GetComponentInChildren<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D player) {


        if (player.gameObject.tag == "LevelFinish") {
            print("NewLevel");
            NewLevel();
        }

        if (player.gameObject.tag == "Instadeath") {
           
            print("TheDeath");
            Health = 0;
        }
        if (player.gameObject.tag == "2Damage") {
            Health=(Health-2);
            Rb2D.velocity = new Vector2(-Rb2D.velocity.x*(1.2f), -Rb2D.velocity.y*(1.2f));

            print("-2");

        }
        if (player.gameObject.tag == "Bounce") {
    
            Rb2D.velocity = new Vector2(0, -Rb2D.velocity.y*(1.1f));


        }




        if (Health <= 0) {
            Rebirth();
        }
    }
    public void NewLevel() {
        // startPosition = new Vector3(0,0,0);
        
        Levelname++;
        StartCoroutine(LoadScene());
    }
    public void Rebirth() {
        // startPosition = new Vector3(0,0,0);
      //  Destroy(gameObject);
        StartCoroutine(LoadScene());
        Health = 5;
    }
    public IEnumerator LoadScene() {
        startLocation = transform;
        Rb2D.velocity = new Vector2(0,0);
        startLocation.SetPositionAndRotation(startPosition, Quaternion.Euler(0, 0, 0));
        startPosition=player.transform.position;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Levelname);

        while (!asyncLoad.isDone) {
            yield return null;

        }

    }
}
