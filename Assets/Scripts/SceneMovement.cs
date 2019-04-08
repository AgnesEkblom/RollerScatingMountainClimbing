using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour
{
    
    public CameraMain C;
    public GameObject Camera;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");

        C = Camera.GetComponent<CameraMain>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    
        Vector3 rotate = new Vector3(0, 1, 0);
       transform.Rotate(((C.sortacameravelocityX) * rotate)/500);
     //   transform.Translate((C.sortacameravelocityX),0,0);
       // transform.position = new Vector3(Camera.transform.position.x,-transform.position.y,-40);

    }
}
