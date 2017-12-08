using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{

    public bool hasDied;
    public int health;

    // Use this for initialization
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -8)
        {
            hasDied = true;
        }

        if (hasDied == true)
        {
            //player dies
            StartCoroutine("Die");
        }
    }



    // lke method or function but can pause for a few seconds
    IEnumerator Die()
    {
        SceneManager.LoadScene("Prototype1");
        yield return null;

        //Debug.Log("Player has fallen");
        //yield return new WaitForSeconds(2);
        //Debug.Log("Player has died");
    }
}
