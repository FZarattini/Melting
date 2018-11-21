using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OST : MonoBehaviour {

    [SerializeField]
    private AudioClip ostClip;
    [SerializeField]
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(audioSource);
	}

    private void Update()
    {
        if(audioSource.isPlaying == false) {
            audioSource.clip = ostClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
