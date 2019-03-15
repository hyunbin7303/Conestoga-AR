using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AROptionScript : MonoBehaviour
{
    public GameObject gameObj;
    public void LinesClear()
    {
        Debug.Log("Lines Clear button Clicked");
        DrawlineScript []checks = gameObj.GetComponentsInChildren<DrawlineScript>();
        foreach (DrawlineScript drawline in checks)
        {
            drawline.lineRenderOff();
        }
    }

}
