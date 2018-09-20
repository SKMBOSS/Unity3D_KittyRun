using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSound : MonoBehaviour {

    public AudioClip Goal_Sound;
    AudioSource sound;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;
        sound.loop = false;
        sound.volume = 1.0f;
        sound.clip = Goal_Sound;
        sound.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
