using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField]
    private ArrayList list;

    [SerializeField]
    private GameObject[] platformsPrefabs;

    [SerializeField]
    private GameObject[] powerUp;

    float posFinal;

    private GameObject lastGenerated;

    private int lastIndex;

    private int index;

    public float[] xPosition;

    public float yPosition;

    public int simplePlatformProbability;

    private bool lastIsSimple;

    private Block block;

    private float offset;

    private float anchorPlatformPosition;

    private int layer;

    private float Z_axis;

    private bool firstGenerated;

    public static bool blockGenerated;

    [SerializeField]
    private int powerUpIndex;

    GameObject plat;

    // Use this for initialization
    void Start()
    {
        blockGenerated = false;

        firstGenerated = false;

        lastIndex = 0;

        posFinal = -6.5f;
  
        lastIsSimple = false;

        block = GetComponent<Block>();

        anchorPlatformPosition = 0f;
        offset = 0f;
        list = new ArrayList();
        platformsPrefabs[0].GetComponent<SpriteRenderer>().sortingOrder = 0;

        //Se aumentar numero de prefabs de plataformas DESCOMENTAR ABAIXOOO E acrescentar

        platformsPrefabs[1].GetComponent<SpriteRenderer>().sortingOrder = 0;

        //More PlatformsPrefabs[2]...
        // ..
    }

    // Update is called once per frame
    void Update()
    {

        //Plataforma inicial
        if (lastGenerated == null && firstGenerated == false)
        {
            Debug.Log("gerando plataforma inicial");
            list.Add(Instantiate(platformsPrefabs[10], new Vector3(Random.Range(0, xPosition.Length), yPosition, 0f), Quaternion.identity));
            lastGenerated = list[lastIndex] as GameObject;

            lastIsSimple = true;
            firstGenerated = true;
        }
        else if (lastIsSimple)
        {
            if (lastGenerated.transform.position.y >= posFinal)
            {
                InvPlatGen();
            }
        }
        else
        {
            if (lastGenerated.GetComponent<LevelSegment>().downmostBlock.transform.position.y >= posFinal)
            {
                InvPlatGen();
            }
        }

    }

    public void InvPlatGen()
    {

        //Simple Platform Generation
        if (Random.Range(0, 10) <= simplePlatformProbability)
        {
            Debug.Log("gerando plataforma simples");
            list.Add(Instantiate(platformsPrefabs[10], new Vector3(xPosition[Random.Range(0, xPosition.Length)], yPosition, 0f), Quaternion.identity));
            lastIndex++;
            lastGenerated = list[lastIndex] as GameObject;
            lastIsSimple = true;
        }
        else
        {
            Debug.Log("gerando level");
            int index = Random.Range(0, platformsPrefabs.Length - 1);
            Debug.Log("size" + platformsPrefabs[index].GetComponent<SpriteRenderer>().bounds.size.y);
            list.Add(Instantiate(platformsPrefabs[index], new Vector3(0f, platformsPrefabs[index].GetComponent<LevelSegment>().yPosition, 0f), Quaternion.identity));
            lastIndex++;
            lastGenerated = list[lastIndex] as GameObject;
            lastIsSimple = false;
        }

        //Block Generation
    }

    /*
    if (list != null && list.Count != 0)
    {

        GameObject lastPlatform;
        if ((GameObject)list[list.Count - 1] != null)
        {
            lastPlatform = (GameObject)list[list.Count - 1];

            anchorPlatformPosition = lastPlatform.transform.position.x;

            if (anchorPlatformPosition > 1.5f)
            {
                anchorPlatformPosition -= 2f;
                Debug.Log(" > 1.5f!!!!!!!! ");
            }
            else if (anchorPlatformPosition < -1.5f)
            {
                anchorPlatformPosition += 2f;
                Debug.Log(" < - 1.5f !!!!!!");
            }
        }else {
            anchorPlatformPosition = 0f;
        }
    }

    CancelInvoke("GeneratePlatforms1");

    CancelInvoke("GeneratePlatforms2");

    //CancelInvoke("GeneratePlatforms3");
    int index = Random.Range(1, 11);

    if (index < 7) {
        InvokeRepeating("GeneratePlatforms" + Random.Range(1, 3).ToString(), 0f, 3.6f / speedUpFactor);

        blockGenerated = false;
    }
    else {

        Invoke("GeneratePlatforms3", 0f);
        blockGenerated = true;
        lastIndex = index;

    }
}


private void GeneratePlatforms1() {

    //GameObject lastPlatform = (GameObject)list[list.Count - 1];

    //anchorPlatformPosition = lastPlatform.transform.position.x;
    //if (anchorPlatformPosition < 1f && anchorPlatformPosition > 1f)
    //{
        if (offset > -4f && offset < 4f)
        {
            if (Random.Range(0, 2) == 0)
            {
                offset++;
            }
            else
            {
                offset--;
            }
        }
        else 
        {
            offset = 0;
        }
    //}
    //Z_axis -= 0.1f;

    plat = platformsPrefabs[Random.Range(0, 1)];

    plat.transform.position = new Vector3(anchorPlatformPosition + offset, -10f, 0f);

    plat.GetComponent<SpriteRenderer>().sortingOrder++;

    list.Add(Instantiate(plat));

    powerUpIndex = Random.Range(0, 10);

    if (powerUpIndex < 4) //6
    {
        list.Add(Instantiate(powerUp[0], new Vector3(plat.transform.position.x, plat.transform.position.y + plat.transform.localScale.y, plat.transform.position.z), Quaternion.identity));
    }
    else if(powerUpIndex >= 8){
        list.Add(Instantiate(powerUp[1], new Vector3(plat.transform.position.x, plat.transform.position.y + plat.transform.localScale.y - 0.3f, plat.transform.position.z), Quaternion.identity));
    }
}

private void GeneratePlatforms2()
{

    if (offset > -2f && offset < 2f)
    {
        if (Random.Range(0, 2) == 0)
        {
            offset--;
        }
        else
        {
            offset++;
        }
    }
    else
    {
        offset = Random.Range(-1f, 0f);
    }
    //Z_axis -= 0.1f;

    plat = platformsPrefabs[Random.Range(0, 1)];

    plat.transform.position = new Vector3(anchorPlatformPosition + offset, -10f, 0f);

    plat.GetComponent<SpriteRenderer>().sortingOrder++;

    list.Add(Instantiate(plat));

    powerUpIndex = Random.Range(0, 10);

    if (powerUpIndex < 6)
    {
        list.Add(Instantiate(powerUp[0], new Vector3(plat.transform.position.x, plat.transform.position.y + plat.transform.localScale.y, plat.transform.position.z), Quaternion.identity));
    }
    else if (powerUpIndex >= 8)
    {
        list.Add(Instantiate(powerUp[1], new Vector3(plat.transform.position.x, plat.transform.position.y + plat.transform.localScale.y - 0.3f, plat.transform.position.z), Quaternion.identity));
    }
}

//Level design1
private void GeneratePlatforms3()
{
    GameObject[] temp =  block.GenerateBlock();
    for (int i = 0; i < temp.Length; i++)
    {
        list.Add(temp[i]);
    }
}
*/
    public ArrayList GetGenPlatforms()
    {
        return list;
    }
}
