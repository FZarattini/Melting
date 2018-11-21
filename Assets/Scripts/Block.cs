using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //public GameObject[] blockList;
    private int randomBlock;
    private GameObject[] blockList;
    public GameObject[] platformPrefab;
    // Use this for initialization
    void Start()
    {
        blockList = new GameObject[8];

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Level Design 1
    public GameObject[] GenerateBlock()
    {
        //randomBlock = Random.Range(1, 7);
        //for (int i = 0; i < 4; i++)
        //{
        //Platform 1
        float bottomOffset = -10f;


        if (Random.Range(0, 3) < 2)
        {
            platformPrefab[0].GetComponent<SpriteRenderer>().sortingOrder++;

            blockList[0] = Instantiate(platformPrefab[0], new Vector3(0f, -10f, 0f), Quaternion.identity);

            platformPrefab[0].GetComponent<SpriteRenderer>().sortingOrder++;

            blockList[1] = Instantiate(platformPrefab[0], new Vector3(0f, -20f, 0f), Quaternion.identity);
        }
        else {
            platformPrefab[1].GetComponent<SpriteRenderer>().sortingOrder++;

            blockList[0] = Instantiate(platformPrefab[1], new Vector3(0f, -10f, 0f), Quaternion.identity);

            platformPrefab[1].GetComponent<SpriteRenderer>().sortingOrder++;

            blockList[1] = Instantiate(platformPrefab[1], new Vector3(0f, -20f, 0f), Quaternion.identity);
        }
        //blockList[0] = Instantiate(platformPrefab, new Vector3(-3.76f, 0f + bottomOffset, 0f), Quaternion.identity);

        //platformPrefab.GetComponent<SpriteRenderer>().sortingOrder++;

        //blockList[1] = Instantiate(platformPrefab, new Vector3(-1.35f, -2.22f + bottomOffset, 0f), Quaternion.identity);

        //platformPrefab.GetComponent<SpriteRenderer>().sortingOrder++;

        //blockList[2] = Instantiate(platformPrefab, new Vector3(1.09f, -4.46f + bottomOffset, 0f), Quaternion.identity);

        //platformPrefab.GetComponent<SpriteRenderer>().sortingOrder++;

        //blockList[3] = Instantiate(platformPrefab, new Vector3(3.67f, -6.67f + bottomOffset, 0f), Quaternion.identity);
        ////}
        //bottomOffset = -20f;

        //blockList[4] = Instantiate(platformPrefab, new Vector3(-3.76f, 0f + bottomOffset, 0f), Quaternion.identity);

        //platformPrefab.GetComponent<SpriteRenderer>().sortingOrder++;

        //blockList[5] = Instantiate(platformPrefab, new Vector3(-1.35f, -2.22f + bottomOffset, 0f), Quaternion.identity);

        //platformPrefab.GetComponent<SpriteRenderer>().sortingOrder++;

        //blockList[6] = Instantiate(platformPrefab, new Vector3(1.09f, -4.46f + bottomOffset, 0f), Quaternion.identity);

        //platformPrefab.GetComponent<SpriteRenderer>().sortingOrder++;

        //blockList[7] = Instantiate(platformPrefab, new Vector3(3.67f, -6.67f + bottomOffset, 0f), Quaternion.identity);

        return blockList;
    }

    //public GameObject[] GetGenBlock()
    //{
    //    return blockList;
    //}
}
