using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartScripts : MonoBehaviour
{
    public static float health;
    public static float numOfhearts;
    private bool setHearts;
    
    public GameObject[] hearts;
    public Transform[] spawnPoints;
   


    
  
    //public Sprite fullHeart;
    //public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        health = 9;
        numOfhearts = 9;
        setHearts = true;
        DontDestroyOnLoad(hearts[3].gameObject);
        DontDestroyOnLoad(hearts[2].gameObject);
        DontDestroyOnLoad(hearts[1].gameObject);
        DontDestroyOnLoad(hearts[0].gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health != numOfhearts)
        {
            numOfhearts = health;
            setHearts = true;
        }


        if (numOfhearts == 9 && setHearts)
        {

            

            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }



        
        if (numOfhearts == 8 && setHearts)
        {
            

            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[2], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }
        if (numOfhearts == 7 && setHearts)
        {
           
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[1], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }
        if (numOfhearts == 6 && setHearts)
        {
          
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }



        if (numOfhearts == 5 && setHearts)
        {
          
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[2], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }
        if (numOfhearts == 4 && setHearts)
        {
         
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[1], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }

        if (numOfhearts == 3 && setHearts)
        {
           
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[3], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }
        if (numOfhearts == 2 && setHearts)
        {
           
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[2], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }
        if (numOfhearts == 1 && setHearts)
        {
           
            Transform theSpot = spawnPoints[0];
            Instantiate(hearts[1], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[1];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            theSpot = spawnPoints[2];
            Instantiate(hearts[0], theSpot.transform.position, Quaternion.identity);
            setHearts = false;
        }


       
        /*
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
        */
    }
    private void OnLevelWasLoaded(int level)
    {
        setHearts = true;
        
    }
}