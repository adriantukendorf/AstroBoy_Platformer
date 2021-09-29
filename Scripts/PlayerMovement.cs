using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed = 30f;
    public bool isGrounded;
    private Rigidbody2D rb;
    public float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    public bool isClimbing; //check if player is currently climbing
    public Animator animator;
    private bool facingRight; //check if player is facing right
    public int currentHealth = 5;
    public TimeManager timeManager;
    public GameObject WinMenu;
    public GameObject FailMenu;
    public float timeInAir = 0;



    void Start() {
        rb = GetComponent<Rigidbody2D>();
        timeManager = FindObjectOfType(typeof(TimeManager)) as TimeManager;
    }

    void FixedUpdate() {
        if (!timeManager.GetComponent<TimeManager>().isReversing && currentHealth>0)
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);


            if (hitInfo.collider != null)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    isClimbing = true;
                }
            }
            else
            {
                isClimbing = false;
            }
            if (isClimbing == true)
            {

                inputVertical = Input.GetAxisRaw("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = 5;
            }
        }
        //Current state send to animator
        animator.SetBool("isClimbing", isClimbing);
        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        animator.SetBool("isGrounded", isGrounded);



        if (inputHorizontal == -1 && !facingRight)
        {
            Flip();
        }
        else if (inputHorizontal == 1 && facingRight)
        {
            Flip();
        }

        
    }

    private void Update()
    {
        Jump();
        DeathByFalling();
        Dying();
        Suicide();
    }

    private void Suicide()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentHealth = 0;
        }
    }

    private void Dying()
    {
        if (currentHealth <= 0)
        {
            FailMenu.SetActive(true);
        }
        else
        {
            FailMenu.SetActive(false);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private void DeathByFalling()
    {
        if (!isGrounded && !isClimbing && !timeManager.GetComponent<TimeManager>().isReversing)
        {
            timeInAir += Time.deltaTime;
            if (timeInAir > 5)
            {
                currentHealth = 0;
            }
        }
        else
        {
            timeInAir = 0;
        }
    }


    public void Damage(int dmg)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmg;
        }
        else
        {
            Debug.Log("You should be already dead.");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Rock"|| collision.collider.tag == "Rock2"|| collision.collider.tag == "Rock3")
        {
            Debug.Log("rock hit me");
            Damage(1);
        }
        if(collision.collider.tag == "FinishPoint")
        {
            WinMenu.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex < 2)
            {
                if (PlayerPrefs.GetInt("level") < SceneManager.GetActiveScene().buildIndex)
                {
                    PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

}
