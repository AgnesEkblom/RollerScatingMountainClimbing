using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goatscript2D : MonoBehaviour
{
    public Rigidbody2D GRB2D;
    public bool GoatTime;
    public GameObject player;
    public PlayerMovement PM;
    public Vector2 currentGoatXPlacement;
    public Vector2 GoatTravel;
    static float t;
    public float currentLerpTime;
    public float HowlongToMoveFor;
    public GameObject Goatbody;
    public PersonalBubbleofGoatScript PBoGS;

    public float GoatSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        GoatTime = true;
        GRB2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        PM = player.GetComponent<PlayerMovement>();
        Goatbody = GetComponentInChildren<GameObject>();
        PBoGS = GetComponentInChildren<PersonalBubbleofGoatScript>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (GoatTime == true)
        {
               StartCoroutine(Goatmovement());

        }
       

    }



    IEnumerator Goatmovement()
    {

        GoatTime = false;

        HowlongToMoveFor = Random.Range(0, 5);

        int LeftOrRight = Random.Range(-1,2);


        if (LeftOrRight == -1)
        {
            Goatbody.transform.localScale = new Vector3(-1, 1, 1);


        }
        else if (LeftOrRight == 0)
        {
            print("[insert gräsätaranimation here]");

        }

        else if (LeftOrRight == 1)
        {
            Goatbody.transform.localScale = new Vector3(1, 1, 1);

        }






        GRB2D.velocity= new Vector2 (5*LeftOrRight,0);









        yield return new WaitForSeconds(HowlongToMoveFor);

        //det kanske är nu du behöver lära dig hur man använder fucking get/set-metoder, agnes, det kanske är fucking dags agnes?





        //  GRB2D.velocity = new Vector2 (5,0);
        // float Goattraveldistance = GRB2D.position/ GoatTravel;





        GoatTime = true;





    }
}
