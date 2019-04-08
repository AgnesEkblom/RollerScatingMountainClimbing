﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InLevel_GUI : MonoBehaviour
{ 
    public float Xposition1;
    public float Yposition1;
    public bool ButtonPressed = false;
    public bool BitchButton= false;
    public GameObject Spawnpackage;
    public GameObject player;
    public SpawnScript SpSc;


    private void Start() {

        Spawnpackage = GameObject.FindGameObjectWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("Player");
        SpSc = player.GetComponent<SpawnScript>();
    }
    private void OnGUI() {

        if (ButtonPressed == false) {
            if (GUI.Button(new Rect(0, 0, 60, 25), "Options")) {
                ButtonPressed = true;
            }

        }
        if (ButtonPressed == true&&BitchButton==false) {
            if (GUI.Button(new Rect(0, 0, 100, 50), "Close")) {
                ButtonPressed = false;
            }
            if (GUI.Button(new Rect(Xposition1, Yposition1, 150, 50), "Return to Main Menu")) {
                ButtonPressed = false;
   //             StartCoroutine(LoadHUB());
            }

        }

        if (SpSc.SceneIsLoading == true)
        {
            print("nån sorts fadein/fadeout varför är gui så jävla KRÅNGLIGT");
        }
    }
/*
    public IEnumerator LoadHUB() {

        Object.Destroy(Spawnpackage);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        

        while (!asyncLoad.isDone) {
            yield return null;

        }

    }*/


}
