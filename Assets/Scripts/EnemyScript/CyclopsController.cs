
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CyclopsController : MonoBehaviour
{
    public Transform playerTarget;
    public float speed;

    public static float enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;

        enemyHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                PlayerController.instance.transform.position, Time.deltaTime * speed);
        }
    }

    private void FixedUpdate()
    {
        if(enemyHP == 0)
        {
            print("im ded");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BodyHitBox")
        {
            HeartScripts.health--;
            print("minus 1 heart");
        }
    }
}