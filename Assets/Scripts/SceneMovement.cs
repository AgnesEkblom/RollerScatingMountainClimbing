using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour
{
    
    public CameraMain C;
    public float vel;
    public Vector3 Placetomoveto;
    // Start is called before the first frame update
    void Start()
    {
        
        C = GetComponentInParent<CameraMain>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    
        Vector3 rotate = new Vector3(0, 1, 0);
       transform.Rotate(((C.sortacameravelocity-10) * rotate)/1000);
    }
}
