using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject HuggingCat;
    public int EnemySpeed;
    public int xMoveDirection;
    private bool facingRight = true;
    private bool canMove;
    private int numRightPressed;
    private int numLeftPressed;
    private Vector2 huggingCatLocalScale;

    // Use this for initialization
    void Start()
    {
        canMove = true;
        numLeftPressed = 0;
        numRightPressed = 0;

        HuggingCat.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            EnemyMove();
        } else
        {
            if (Input.GetKeyDown("left"))
            {
                numLeftPressed += 1;
                HuggingCat.gameObject.GetComponent<Rigidbody2D>().MoveRotation(10);
                Debug.Log("left pressed");
            }
            if (Input.GetKeyDown("right"))
            {
                HuggingCat.gameObject.GetComponent<Rigidbody2D>().MoveRotation(-10);
                numRightPressed += 1;
                Debug.Log("right pressed");
            }

            if (numLeftPressed > 20 && numRightPressed > 20)
            {
                numRightPressed = 0;
                numLeftPressed = 0;
                FlipEnemy();
                HuggingCat.gameObject.SetActive(false);
                canMove = true;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    private void EnemyMove()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallForEnemy")
        {
            FlipEnemy();
        } else if (collision.gameObject.tag == "Player")
        {
            if (Player.gameObject.GetComponent<PlayerMovement>().isFurBall == false)
            {
                canMove = false;
                
                HuggingCat.gameObject.transform.position = new Vector3 (gameObject.GetComponent<Rigidbody2D>().position.x, gameObject.GetComponent<Rigidbody2D>().position.y, -2);
                HuggingCat.gameObject.SetActive(true);

                //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                //Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                //yield return new WaitForSeconds(5);

                //StartCoroutine("HugCat");
            } else
            {
                FlipEnemy();
            }
            
        }
        

    }

    void FlipEnemy()
    {
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        }
        else
        {
            xMoveDirection = 1;
        }
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    IEnumerator HugCat()
    {
        
        canMove = false;
        yield return new WaitForSeconds(1);
        while (numRightPressed <20 && numLeftPressed < 20)
        {
            if (Input.GetKeyDown("left"))
            {
                numLeftPressed += 1;
                Debug.Log("left pressed");
            }
            if (Input.GetKeyDown("right"))
            {
                numRightPressed += 1;
                Debug.Log("right pressed");
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        numRightPressed = 0;
        numLeftPressed = 0;
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //yield return new WaitForSeconds(5);
        
        FlipEnemy();
        canMove = true;
        
    }
}
