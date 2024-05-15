using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheseusDestroyer : MonoBehaviour
{


    float endTime;
    // Start is called before the first frame update
    void Start()
    {
        endTime = Time.time + 4.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (endTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
