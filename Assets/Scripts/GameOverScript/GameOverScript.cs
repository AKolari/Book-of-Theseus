using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
   float spawningText;
   
    // Start is called before the first frame update
    void Start()
    {
       spawningText = Time.time + 10f;

    }

    // Update is called once per frame
    void Update()
    {
       if (spawningText < Time.time)
        {
         
            if (Input.anyKey){
            
                SceneManager.LoadScene(0);
            }
        }
    }
}
