using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurgeonEnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public int EnemySpeed;
    public int xMoveDirection;
    private bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
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
        }
        else if (collision.gameObject.tag == "Player")
        {
           
            if (Player.gameObject.GetComponent<PlayerMovement>().isFurBall == false)
            {
                StartCoroutine("Die");
            }
            else
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

    IEnumerator Die()
    {
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
