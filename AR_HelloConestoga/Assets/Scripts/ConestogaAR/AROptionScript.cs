
using UnityEngine;

public class AROptionScript : MonoBehaviour
{

    public GameObject gameObj;
    public GameObject CampusMapObj;
    public void LinesClear()
    {
        foreach (DrawlineScript drawline in gameObj.GetComponentsInChildren<DrawlineScript>())
        {
            drawline.lineRenderOff();
            //Should I Destroy the whole lines? 
        }
        foreach (Renderer renderer in CampusMapObj.GetComponentsInChildren<Renderer>())
        {
            renderer.material.color = Color.white;
        }
    }

    public void ChangeBlue()
    {

    }

}
