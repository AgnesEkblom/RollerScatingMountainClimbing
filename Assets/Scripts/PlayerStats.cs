using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int Health;
    public bool HasDied;
    public SpawnScript SpSc;
    // Use this for initialization
    private void Awake() {
        HasDied = false;
        SpSc=GetComponentInParent<SpawnScript>();
    }
    void Start () {
		
	}
    


    // Update is called once per frame
    /*void Update () {
		if (Health == 0) {
            Die();
        }
	}
    public void Die() {
        HasDied = true;

        HasDied = false;
    }*/
}
