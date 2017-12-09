using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {
    public GameObject loadingImage;

    public void LoadScene(int level)
    {
        if (level == 999)
        {
            Application.Quit();
        }

        loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
