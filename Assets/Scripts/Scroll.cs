using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    [SerializeField]
    private Platform platform;
    [SerializeField]
    private BG background;

    private ArrayList list;

    [SerializeField]
    private float speedUpScenario;

    [SerializeField]
    private float speedLeft;

    //Flag to point that it is time to generate mre BGs

    public static bool flagForGeneration;


    // Use this for initialization
    void Start()
    {
        flagForGeneration = false;
        platform = GetComponent<Platform>();
        background = GetComponent<BG>();
        list = new ArrayList();

        //StartCoroutine(Effects());

    }


	
	// Update is called once per frame
	void Update () {
        Scrolls(Generator.GetGeneratedObjs());
        Scrolls(platform.GetGenPlatforms());
        Culling(Generator.GetGeneratedObjs());
        Culling(platform.GetGenPlatforms());
    }

    public float GetSpeedUp()
    {
        return speedUpScenario;
    }

    public void SetSpeedUp(float speedUp)
    {
        speedUpScenario = speedUp;
    }
    //IEnumerator Effects() {
    //    while(true) {

    //        //foreach (GameObject o in Generator.GetGeneratedObjs())
    //        //{
               
    //        if (GameObject.FindWithTag("LavaBubble"))
    //        {
    //            GameObject.FindWithTag("LavaBubble").transform.localScale =
    //                          new Vector3(Mathf.PingPong(GameObject.FindWithTag("LavaBubble").transform.localScale.x, 1f) * Time.deltaTime + 0.5f, 1f);
    //        }
    //        yield return new WaitForSeconds(1f);
                
    //        //}
    //        //yield return null;
    //    }
    //}

    void Scrolls(ArrayList gen) {


        foreach(GameObject o in gen) {
            if (o != null)
            {
                o.transform.position += Vector3.up * Time.deltaTime * speedUpScenario;


                if (o.tag == "LavaPathR")
                {
                    o.transform.position += (Vector3.left * 0.3f) * Time.deltaTime * speedLeft;
                }
                else if(o.tag == "LavaPathL")
                {
                    o.transform.position += (Vector3.right * 0.3f) * Time.deltaTime * speedLeft;
                }
                //if (o.tag == "LavaBubble")
                //{
                //    o.transform.localScale = new Vector3(Mathf.PingPong(o.transform.localScale.x, 1f) + 0.5f, 1f);
                //}



            }

        }
    }

    void Culling(ArrayList gen) {
        foreach (GameObject o in gen)
        {
            if (o != null)
            {
                if (o.tag == "Tile" && !o.name.Contains("LevelDesign") && o.transform.position.y > 52f) {
                    Destroy(o.gameObject);
                }
                if (o.name.Contains("LevelDesign") && o.transform.position.y > 30f) //nao tah funfando
                {
                    Destroy(o.gameObject);
                }
                if (o.tag == "LavaBubble" && o.transform.position.y > 10f)
                {
                    Destroy(o.gameObject);
                }
                if (o.transform.position.y > 52f)
                {
                    Destroy(o.gameObject);
                }

               
                //Lava Path
                if (o.transform.position.y >= 1f && flagForGeneration == false)
                {
                    flagForGeneration = true;
                }

            }
        }
    }

    public IEnumerator NormaliseSpeedUp()
    {
        while (true)
        {
            if(speedUpScenario > 5f)
            {
                yield return new WaitForSeconds(5f);
                //speedUpScenario -= 1f;
                speedUpScenario = 5f;
            }
            else {
                yield return null;
            }
        }
    }
}
