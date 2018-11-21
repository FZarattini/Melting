using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private float offset;
    private float maxOffset;
    private bool toLeft;
    // Use this for initialization
    void Start()
    {
        toLeft = false;
        offset = 0.1f;
        maxOffset = 2f;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag != "Heal")
        {
            if (toLeft == false)
            {
                transform.Translate(Vector3.right * offset * Time.deltaTime);
                offset += 0.2f;
                if(offset > maxOffset) {
                    toLeft = true;
                }
            }
            if(toLeft == true) {
                transform.Translate(Vector3.left * offset * Time.deltaTime);
                offset += 0.2f;
                if(offset > 0f)
                {
                    toLeft = false;
                }
            }
        }
	}

}
