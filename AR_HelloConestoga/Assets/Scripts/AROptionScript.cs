using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AROptionScript : MonoBehaviour
{
    public GameObject gameObj;
    public GameObject CampusMapObj;
    public GameObject userObj;
    public void LinesClear()
    {
        foreach (DrawlineScript drawline in gameObj.GetComponentsInChildren<DrawlineScript>())
        {
            drawline.lineRenderOff();
        }
        foreach (Renderer renderer in CampusMapObj.GetComponentsInChildren<Renderer>())
        {
            renderer.material.color = Color.white;
        }
    }

    public void PlaceObjectsInSpot()
    {
        userObj.SetActive(true);
    }

   

}
