using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinotaurScript : MonoBehaviour
{
    public Transform playerTarget;
    public float speed;

    public static float minotaurHP;

    public Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;

        minotaurHP = 10;
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
        if (minotaurHP == 0)
        {
            print("Im ded");
            SceneManager.LoadScene(11);
            Destroy(GameObject.FindWithTag("Player"));  
 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BodyHitBox")
        {
            HeartScripts.health--;
            HeartScripts.health--;
            HeartScripts.health--;
            HeartScripts.health--;
            print("minus 4 hearts");
        }
    }
}
