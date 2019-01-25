using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HublevelScript : MonoBehaviour {
    public Texture btnTexture;
    public int Level;


    [Header("Startmeny")]
    public float Xposition1;
    public float Yposition1;
    public float Xposition2;
    public float Yposition2;
    public float Xposition3;
    public float Yposition3;
    public float XBackposition;
    public float YBackposition;

    public bool Step1;
    public bool Step2;

    public GameObject Spawnpackage;


    private void Start() {
        Step1 = true;
        GameObject Spawnpackage = gameObject.GetComponent<GameObject>();
    }

    void OnGUI() {
        if (!btnTexture) {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }
        if (Step1 == true){
            if (GUI.Button(new Rect(Xposition1, Yposition1, 100, 50), "Start Game")) {
                Level = 1;
                StartCoroutine(LoadScene());


            }

            if (GUI.Button(new Rect(Xposition2, Yposition2, 100, 50), "Select Level")) {
                Step1 = false;
                Step2 = true;

            }
            if (GUI.Button(new Rect(Xposition3, Yposition3, 100, 50), "Quit")) {
                Application.Quit();
            }
        }
        if (Step2 == true) {
            if (GUI.Button(new Rect(Xposition1, Yposition1, 100, 50), "Level 1")) {
                Level = 1;
                StartCoroutine(LoadScene());
            }

            if (GUI.Button(new Rect(Xposition2, Yposition2, 100, 50), "Level 2")) {
                Level = 2;
                StartCoroutine(LoadScene());
            }
            if (GUI.Button(new Rect(Xposition3, Yposition3, 100, 50), "Level 3")) {
                Level = 3;
                StartCoroutine(LoadScene());
            }
            if (GUI.Button(new Rect(XBackposition, YBackposition, 100, 50), "Back")) {
                Step2 = false;
                Step1 = true;
            }

        }
    }
    public IEnumerator LoadScene() {
        Instantiate(Spawnpackage, new Vector3(0, 0, 0), Quaternion.identity);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Level);

        while (!asyncLoad.isDone) {
            yield return null;

        }

    }
}