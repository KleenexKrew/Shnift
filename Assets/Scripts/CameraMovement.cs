using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        { //Makes sure player is present
          // First find the player's current location
            Vector2 playerLoc = player.transform.position;
            // Determine where this camera should be
            Vector3 newPosition = new Vector3(playerLoc.x, playerLoc.y, -10f);
            // Place camera at new location
            this.transform.position = newPosition;
        }
    }
}

