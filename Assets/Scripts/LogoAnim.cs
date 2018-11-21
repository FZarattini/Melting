using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoAnim : MonoBehaviour {

    [SerializeField]
    private GameObject logo;

    private float alpha;

    private bool fadeInTime;

    private bool fadeOutEnd;

    private float timer;

    [SerializeField]
    private string scene;

    [SerializeField]
    private float timeMax;
	// Use this for initialization
	void Start () {
        alpha = 0f;
        fadeInTime = true;
        fadeOutEnd = false;
        timer = Time.time;
	}

    private void Update()
    {
        timer = Time.time;
        if (alpha < 1f && fadeInTime)
        {
            FadeIn();
        }
        else if(timer > timeMax / 2){
            fadeInTime = false ;
            FadeOut();
        }
        if(timer > timeMax) {
            SceneManager.LoadScene(scene);
        }
    }

    private void FadeIn() 
    {
        logo.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha += 1.5f * Time.deltaTime);
    }

    private void FadeOut() 
    {
        logo.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha -= 1.2f * Time.deltaTime);
    }
}
