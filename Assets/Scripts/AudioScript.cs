using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public AudioClip[] Backgroundmusic;
    public AudioMixerGroup output;
    // Start is called before the first frame update

    void Start() {
        PlayBackgroundMusic();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void PlayBackgroundMusic() {

        int randomClip = Random.Range(0, Backgroundmusic.Length);
        AudioSource source = gameObject.AddComponent<AudioSource>();

        source.clip = Backgroundmusic[randomClip];
        source.outputAudioMixerGroup = output;
        print("ey");
        source.Play();

    }
}
