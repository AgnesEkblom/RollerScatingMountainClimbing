using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalBubbleofGoatScript : MonoBehaviour
{
    public Goatscript2D Gs2D;
    public PlayerMovement PM;
    public GameObject player;
    public GameObject Goatbody;
    public Rigidbody2D GRB2D;
    public Vector2 DirectionVector;


    // Start is called before the first frame update
    void Start()
    {
        Gs2D = GetComponentInParent<Goatscript2D>();
        GRB2D = GetComponentInParent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        PM = player.GetComponent<PlayerMovement>();
        Goatbody = GetComponentInChildren<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            //  if (Vector3.Distance(transform.position, GRB2D.position) > 0.1)
            
                float direction = transform.position.x- PM.rb2D.position.x;
                DirectionVector = new Vector2(-direction, 0);
            print(DirectionVector.normalized);
            if (DirectionVector.normalized.x == -1)
                Goatbody.transform.localScale = new Vector3(-1, 1, 1);
            else if (DirectionVector.normalized.x == 1)
                Goatbody.transform.localScale = new Vector3(1, 1, 1);
            Gs2D.GRB2D.AddRelativeForce(DirectionVector.normalized* 40, ForceMode2D.Impulse);
            
        }

    }

}
