using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour
{
    public PlayerMovement PM;
    public CameraMain C;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
        PM = GetComponentInParent<PlayerMovement>();
      
    }

    // Update is called once per frame
    void Update()
    {
          vel = -PM.rb2D.velocity.x/1000;
        Vector3 rotate = new Vector3(0, 1, 0);
        transform.Rotate(vel * rotate);
    }
}
