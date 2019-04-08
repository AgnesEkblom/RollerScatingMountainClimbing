using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{

    public int Levelname;
    public Transform startLocation;
    public Vector2 startPosition;

    public Rigidbody2D Rb2D;
    public PlayerMovement PM;
    public Goatscript2D GS2D;
    public GameObject Goat;
    public int Health;
    public int FullHealth;
    public int lastValue;
    private Animator A;
    public float windStrength;
    public float boost;
    private bool recentDamage = false;
    public bool SceneIsLoading;
    // Use this for initialization
    public void Awake()
    {

        SceneIsLoading = false;



    }
    void Start()
    {
        Health = FullHealth;
        Levelname = 1;
        A = GetComponent<Animator>();


        PM = GetComponent<PlayerMovement>();

        Rb2D = GetComponentInChildren<Rigidbody2D>();
        Goat = GameObject.FindGameObjectWithTag("Goat");


        GS2D = Goat.GetComponent<Goatscript2D>();


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HarmCheck());
        if (PM.rb2D.velocity.y < 0)
            boost = -PM.rb2D.velocity.y;
        else boost = 0;
    }
    public void OnTriggerEnter2D(Collider2D player)
    {


        if (player.gameObject.tag == "LevelFinish")
        {
            print("NewLevel");
            NewLevel();
        }

        if (player.gameObject.tag == "Instadeath")
        {

            print("TheDeath");
            Health = 0;
        }
        if (player.gameObject.tag == "2Damage")
        {
            Health = (Health - 2);
            Rb2D.velocity = new Vector2(-Rb2D.velocity.x, -Rb2D.velocity.y + 5);


        }




        if (Health <= 0)
        {
            Rebirth();
        }
    }
    public void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "WindUpwards")
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x * 0.9f, Rb2D.velocity.y + 2.5f + windStrength);


            // float movementY = Input.GetAxis("Jump");
               if (Input.GetButtonDown("Jump"))
               {
                   StartCoroutine(WindJump());
               }
        }
        if (player.gameObject.tag == "Goat")
        {
            Rb2D.velocity = new Vector2(-Rb2D.velocity.x, 15);
            Health = (Health - 1);
        }
        if (player.gameObject.tag == "HotWindUpwards")
        {

            if (recentDamage == false)
            StartCoroutine(Smallbreak());
            
            Rb2D.velocity = new Vector2(Rb2D.velocity.x * 0.9f, Rb2D.velocity.y + 2.5f + windStrength);
            


            // float movementY = Input.GetAxis("Jump");
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(WindJump());
            }

        }

    }
    IEnumerator Smallbreak()
    {
        recentDamage = true;
        yield return new WaitForSeconds(2);
        Health -= 1;
        recentDamage = false;





    }
    IEnumerator HarmCheck()
    {
        int currentValue = Health;
        if (currentValue != lastValue)
        {

            A.SetBool("isHurt", true);
            yield return new WaitForSeconds(1);
            A.SetBool("isHurt", false);

            lastValue = Health;
        }

        else
        {
            A.SetBool("isHurt", false);
        }
    }
    IEnumerator WindJump()
    {
        Vector2 chill = new Vector2(0, PM.rb2D.velocity.y / 2);
        Vector2 windjump = new Vector2(0, 1000);
        PM.rb2D.velocity = chill;
        yield return new WaitForSeconds(0.1f);
        PM.rb2D.AddForce((windjump * (boost + 10)));

    }
    public void NewLevel()
    {
        // startPosition = new Vector3(0,0,0);

        Levelname++;
        StartCoroutine(LoadScene());
    }
    public void Rebirth()
    {
        // startPosition = new Vector3(0,0,0);
        //  Destroy(gameObject);
        StartCoroutine(LoadScene());
        Health = FullHealth;
    }
    public IEnumerator LoadScene()
    {
        SceneIsLoading = true;
        startLocation = transform;
        Rb2D.velocity = new Vector2(0, 0);
        startLocation.SetPositionAndRotation(startPosition, Quaternion.Euler(0, 0, 0));
        startPosition = Rb2D.transform.position;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Levelname);
        yield return new WaitForSeconds(0.1f); 
        SceneIsLoading = false;

        while (!asyncLoad.isDone)
        {
            yield return null;

        }

    }
}
