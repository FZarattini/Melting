using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {

    [SerializeField]
    private GameObject[] objs;

    [SerializeField]
    private GameObject redBackground;
    // Use this for initialization
	void Start () {

        Instantiate(redBackground, transform);
	}

    public GameObject[] GetObjs() {
        return objs;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
