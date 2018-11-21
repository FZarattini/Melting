using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    [SerializeField]
    private Scroll scroll;

    [SerializeField]
    private BG background;

    [SerializeField]
    private Platform platform;

    private Block block;

    private static ArrayList list;

    public ArrayList blocksList;

    private GameObject[] bgObjs;



    private bool first;

    public int blockMaxProbablity;

    private int oddLavaLine;
    // Use this for initialization
    void Start()
    {
        first = true;

        oddLavaLine = 0;
        //scroll = GetComponent<Scroll>();

        list = new ArrayList();

        bgObjs = background.GetObjs();

        GenerateLavaLines();

        Invoke("GenerateLavaLines", 2f / scroll.GetSpeedUp());

        StartCoroutine(GenerationCorout());

        StartCoroutine(GenerationRocksCorout());
        //InvokeRepeating("Generate", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GenerationCorout()
    {
        while (true)
        {
            //yield return new WaitForSeconds(3f);
            yield return new WaitForSeconds(3f / scroll.GetSpeedUp());

            GenerateLavaLines();


        }
    }

    IEnumerator GenerationRocksCorout()
    {
        while (true)
        {
            GenerateRocks();

            yield return new WaitForSeconds(6f);

        }
    }

    void GenerateLavaLines()
    {
        Vector2 temp1;

        Vector2 temp2;

        if (first)
        {
            first = false;

            //temp1 = bgObjs[ Random.Range(0, 5) ].transform.position = new Vector2(Random.Range(2.5f, 4.5f), 0f);
            temp1 = new Vector3(Random.Range(2.5f, 4.5f), 0f);

            //temp2 = bgObjs[Random.Range(0, 5) ].transform.position = new Vector2(Random.Range(-2.5f, -3.5f), 2f);

            temp2 = new Vector3(Random.Range(-2.5f, -3.5f), 2f);
        }
        else
        {

            //bgObjs[ Random.Range(0, 5) ].transform.position = new Vector2(Random.Range(2.5f, 4.5f), Random.Range(-9f, -10f) );

            temp1 = new Vector3(Random.Range(2.5f, 4.5f), Random.Range(-8f, -9f));

            temp2 = new Vector3(Random.Range(-1.5f, -3.5f), Random.Range(-9f, -10f));
            //bgObjs[ Random.Range(0, 5) ].transform.position = new Vector2(Random.Range(-2.5f, -3.5f), Random.Range(-9f, -10f) );

        }

        int idx = Random.Range(0, 8);

        bgObjs[idx].transform.position = temp1;

        list.Add(Instantiate(bgObjs[idx]));

        idx = Random.Range(0, 8);

        bgObjs[idx].transform.position = temp2;

        list.Add(Instantiate(bgObjs[idx]));
    }

    void GenerateRocks()
    {
        for (int i = 2; i < bgObjs.Length; i++)
        {
            bgObjs[i].transform.position = new Vector2(Random.Range(-4.5f, 4.5f), -15f);

            list.Add(Instantiate(bgObjs[Random.Range(1, bgObjs.Length - 1)]));
        }
    }



    public static ArrayList GetGeneratedObjs()
    {
        return list;
    }
}
