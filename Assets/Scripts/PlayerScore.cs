using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Main");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // end level -- change scene to the next level??
        if (collision.gameObject.tag == "EndLevel")
        {
            Debug.Log("touched end of level");
            CountScore();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Coin")
        //{
        //    playerScore += 10;
        //    Destroy(collision.gameObject);
        //}
    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft);

    }
}
