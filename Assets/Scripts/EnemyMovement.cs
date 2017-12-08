using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public GameObject Player;
    public int EnemySpeed;
    public int xMoveDirection;
    private bool facingRight = true;
    private bool canMove;

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
            
            EnemyMove();
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
            canMove = false;
            StartCoroutine("HugCat");
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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(5);
        
        FlipEnemy();
        canMove = true;
        
    }
}
