using System.Collections;
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


    private void Start() {
        GameObject Spawnpackage = gameObject.GetComponent<GameObject>();

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
                StartCoroutine(LoadHUB());
            }
            if (GUI.Button(new Rect(0, 200, 20, 25), ";)")) {
                BitchButton = true;

            }
        }
        if (BitchButton == true){
            if (GUI.Button(new Rect(0, 200, 60, 25), "Betch")) {
                BitchButton = false;
            }
        }
    }

    public IEnumerator LoadHUB() {

        Object.Destroy(Spawnpackage);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        

        while (!asyncLoad.isDone) {
            yield return null;

        }

    }


}
