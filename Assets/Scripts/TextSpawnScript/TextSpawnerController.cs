using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawnerController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private float[] spawnText;
    private bool[] spawnedText;
    public GameObject[] text;
    // Start is called before the first frame update
    void Start()
    {
        spawnText = new float[3];
        spawnText[0] = Time.time + 4.5f;
        spawnText[1] = Time.time + 7.5f;
        spawnText[2] = Time.time + 9.75f;

        //Added booleans to stop unity from spawning text forever
        spawnedText = new bool[3];
        spawnedText[0] = false;
        spawnedText[1] = false;
        spawnedText[2] = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnText[0] < Time.time && !spawnedText[0])
        {
            Transform theSpot = spawnPoints[0];
            Instantiate(text[0], theSpot.transform.position, Quaternion.identity);
            spawnedText[0] = true;
        }
        if (spawnText[1] < Time.time && !spawnedText[1])
        {
            Transform theSpot = spawnPoints[1];
            Instantiate(text[1], theSpot.transform.position, Quaternion.identity);
            spawnedText[1] = true;
        }
        if (spawnText[2] < Time.time && !spawnedText[2])
        {
            Transform theSpot = spawnPoints[2];
            Instantiate(text[2], theSpot.transform.position, Quaternion.identity);
            spawnedText[2] = true;
        }


    }
}
