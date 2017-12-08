using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AnimatorOverrideController FatCatAnimator; // Set this in the Inspector
    public int playerSpeed = 10;
    public bool isSkinnyCat = true;
    private bool canMove;
    private bool facingRight = false;
    private float moveX;
    private float moveY;

    // Use this for initialization
    void Start()
    {
        canMove = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            PlayerMove();
        }
        
    }

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        
        //ANIM
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2
            (moveX * playerSpeed, moveY * playerSpeed);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HealthyFood")
        {
            Debug.Log("ATE A HEALTHHHHH");
            Destroy(collision.gameObject);
            BecomeSkinnyCat();
        } else if (collision.gameObject.tag == "FatFood")
        {
            Debug.Log("ATE A FATTTTTt");
            Destroy(collision.gameObject);
            BecomeFatCat();
        } else if (collision.gameObject.tag == "CatLoverEnemy")
        {
            Debug.Log("CAT LOVERRRRRRRRRR");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            canMove = false;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CatLoverEnemy")
        {
            canMove = true;
        }
    }

    void BecomeFatCat()
    {
        if (isSkinnyCat == true)
        {
            // ANIMATE
            // idk how to animate??
            GetComponent<Animator>().runtimeAnimatorController = FatCatAnimator;

            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= 2;
            localScale.y *= 2;
            transform.localScale = localScale;

            isSkinnyCat = false;
        }

       
    }

    void BecomeSkinnyCat()
    {
        if (isSkinnyCat == false)
        {
            // ANIMATE
            // idk how to animate??
            GetComponent<Animator>().runtimeAnimatorController = FatCatAnimator;

            Vector2 localScale = gameObject.transform.localScale;
            localScale.x /= 2;
            localScale.y /= 2;
            transform.localScale = localScale;

            isSkinnyCat = true;
        }
    }
}

