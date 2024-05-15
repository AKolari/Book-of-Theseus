using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float xSpeed, ySpeed, maxSpeed, acceleration, deceleration;
    private bool updateXPos, updateYPos, updateXNeg, updateYNeg;

    public float speed;

    public Rigidbody2D rb;

    private static PlayerController _instance;

    private bool isFacingRight;
    private Animator anim;

    public AudioSource soundFX;
    public AudioClip swordAttack, backgroundMusic;
    

    public static PlayerController instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;

        }else if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0;
        ySpeed = 0;

        maxSpeed = 2;
        acceleration = 2;
        deceleration = 100;

        updateXNeg = true;
        updateXPos = true;
        updateYNeg = true;
        updateYPos = true;

        anim = GetComponent<Animator>();
        isFacingRight = true;
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttacking", false);

        rb = GetComponent<Rigidbody2D>();

        DontDestroyOnLoad(this);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isAttacking", true);
            soundFX.PlayOneShot(swordAttack);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void FixedUpdate()
    {
        if(HeartScripts.health == 0)
        {
            print("Player dead");
            Destroy(this.gameObject);
            SceneManager.LoadScene(10);
        }
 //if(MinotaurScript.minotaurHP == 0)
        //{
            
           // Destroy(this.gameObject);
          // SceneManager.LoadScene(11);
      //  }

        //The following is how to calculate 2D motion, with acceleration, discounting gravity (top down perspective).

        if ((Input.GetKey(KeyCode.A)) && (xSpeed > -maxSpeed) && updateXNeg)
        {
            xSpeed = xSpeed - acceleration * Time.deltaTime;
            anim.SetBool("isWalkingDown", false);
            anim.SetBool("isWalkingUp", false);
            anim.SetBool("isLookingUp", false);
            anim.SetBool("isLookingDown", false);
        }
        else if ((Input.GetKey(KeyCode.D)) && (xSpeed < maxSpeed) && updateXPos)
        {
            xSpeed = xSpeed + acceleration * Time.deltaTime;
            anim.SetBool("isWalkingDown", false);
            anim.SetBool("isWalkingUp", false);
            anim.SetBool("isLookingUp", false);
               anim.SetBool("isLookingDown", false);
        }
        else
        {
            if (xSpeed > deceleration * Time.deltaTime)
            {
                xSpeed = xSpeed - deceleration * Time.deltaTime;
                anim.SetBool("isWalkingDown", false);
                anim.SetBool("isWalkingUp", false);
            }
            else if (xSpeed < -deceleration * Time.deltaTime)
            {
                xSpeed = xSpeed + deceleration * Time.deltaTime;
                anim.SetBool("isWalkingDown", false);
                anim.SetBool("isWalkingUp", false);
            }
            else
                xSpeed = 0;
        }


        if ((Input.GetKey(KeyCode.S)) && (ySpeed > -maxSpeed) && updateYPos)
        {
            ySpeed = ySpeed - acceleration * Time.deltaTime;
            anim.SetBool("isWalkingDown", true);
            anim.SetBool("isWalkingUp", false);
		    anim.SetBool("isLookingUp", false);
            anim.SetBool("isLookingDown", true);

            if (Input.GetMouseButton(0))
            {
                anim.SetBool("isAttackingDown", true);
                soundFX.PlayOneShot(swordAttack);
            }
            else
            {
                anim.SetBool("isAttackingDown", false);
            }
        }
        else if ((Input.GetKey(KeyCode.W)) && (ySpeed < maxSpeed) && updateYNeg)
        {
            ySpeed = ySpeed + acceleration * Time.deltaTime;
            anim.SetBool("isWalkingUp", true);
            anim.SetBool("isWalkingDown", false);
            anim.SetBool("isLookingUp", true);
               anim.SetBool("isLookingDown", false);
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("isAttackingUp", true);
                soundFX.PlayOneShot(swordAttack);
            }
            else
            {
                anim.SetBool("isAttackingUp", false);
            }
        }
        else
        {
            if (ySpeed > deceleration * Time.deltaTime)
                ySpeed = ySpeed - deceleration * Time.deltaTime;
            else if (ySpeed < -deceleration * Time.deltaTime)
                ySpeed = ySpeed + deceleration * Time.deltaTime;
            else
                ySpeed = 0;
        }

        Vector2 moving = new Vector2(xSpeed, ySpeed);

        if(xSpeed != 0f || ySpeed != 0f)
        {
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isIdle", true);
        }
        
        if((xSpeed > 0.0f && !isFacingRight) || (xSpeed < 0.0f && isFacingRight))
        {
            Flip();
            anim.SetBool("isWalkingDown", false);
            anim.SetBool("isWalkingUp", false);
        }

        GetComponent<Rigidbody2D>().velocity = moving;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = this.transform.localScale;
        playerScale.x *= -1;
        this.transform.localScale = playerScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "RightBorder")
        {
            xSpeed = 0;
            updateXPos = false;
        }
        if (collision.gameObject.name == "TopBorder")
        {
            ySpeed = 0;
            updateYNeg = false;
        }
        if (collision.gameObject.name == "LeftBorder")
        {
            xSpeed = 0;
            updateXNeg = false;
        }
        if (collision.gameObject.name == "BottomBorder")
        {
            ySpeed = 0;
            updateYPos = false;
        }

        if(collision.gameObject.tag == "Bat" || collision.gameObject.tag == "Bat" || collision.gameObject.tag == "Bat")
        {
            print("I hit the " + collision.gameObject.name);
            BatController.enemyHP--;
        }
 if(collision.gameObject.tag == "Cyclops" || collision.gameObject.tag == "Cyclops" || collision.gameObject.tag == "Cyclops")
        {
            print("I hit the " + collision.gameObject.name);
            CyclopsController.enemyHP--;
        }
 if(collision.gameObject.tag == "Gorgon" || collision.gameObject.tag == "Gorgon" || collision.gameObject.tag == "Gorgon")
        {
            print("I hit the " + collision.gameObject.name);
            GorgonController.enemyHP--;
        }

 if(collision.gameObject.tag == "Minotaur")
        {
            print("i hit the " + collision.gameObject.name);
            MinotaurScript.minotaurHP--;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RightBorder")
        {

            updateXPos = true;
        }
        if (collision.gameObject.name == "TopBorder")
        {

            updateYNeg = true;
        }
        if (collision.gameObject.name == "LeftBorder")
        {

            updateXNeg = true;
        }
        if (collision.gameObject.name == "BottomBorder")
        {
            updateYPos = true;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }
}
