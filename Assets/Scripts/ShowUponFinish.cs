using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUponFinish : MonoBehaviour {
    public GameObject finishImage;

    public void showFinishMessage(int i)
    {
        finishImage.SetActive(true);
    }
}
