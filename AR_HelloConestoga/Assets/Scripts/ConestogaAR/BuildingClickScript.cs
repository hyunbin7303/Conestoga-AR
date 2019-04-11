using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingClickScript : MonoBehaviour
{
    public TextMeshPro textMeshDescription;
    public string[] strBuildings;
    private string ClickedBuiliding;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchPrev;
    private RaycastHit hit;
    private GameObject lineObj_MainToRec;
    public GameObject mainGameObj;
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000, Color.green, 10, false);
            if (Physics.Raycast(ray, out hit))
            {
                ClickedBuiliding = hit.transform.name;
                Debug.Log("Object Name is : " + ClickedBuiliding);
                switch (ClickedBuiliding)
                {
                    case "Loc_RecCentre":
                        if (GameObject.Find("Line_main_rec").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_rec");
                            if (tempObj.GetComponent<DrawlineScript>().getLineRender())
                                tempObj.GetComponent<DrawlineScript>().lineRenderOff();
                            else
                                tempObj.GetComponent<DrawlineScript>().lineRenderOn();
                        }
                        break;
                    case "Loc_ATC":
                        if (GameObject.Find("Line_main_ATC").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_ATC");
                            if (tempObj.GetComponent<DrawlineScript>().getLineRender())
                                tempObj.GetComponent<DrawlineScript>().lineRenderOff();
                            else
                                tempObj.GetComponent<DrawlineScript>().lineRenderOn();
                        }
                        break;
                    case "Loc_WelcomeCentre":
                        if (GameObject.Find("Line_main_WelcomeCentre").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_WelcomeCentre");
                            if (tempObj.GetComponent<DrawlineScript>().getLineRender())
                                tempObj.GetComponent<DrawlineScript>().lineRenderOff();
                            else
                                tempObj.GetComponent<DrawlineScript>().lineRenderOn();
                        }
                        break;
                    case "Loc_WS":
                        if (GameObject.Find("Line_main_Awing").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_Awing");
                            tempObj.GetComponent<DrawlineScript>().lineRenderOn();
                            if (GameObject.Find("Line_Awing_Woodskill").name != null)
                            {
                                GameObject tempObj2 = GameObject.Find("Line_Awing_Woodskill");
                                if (tempObj2.GetComponent<DrawlineScript>().getLineRender())
                                {
                                    tempObj2.GetComponent<DrawlineScript>().lineRenderOff();
                                    tempObj.GetComponent<DrawlineScript>().lineRenderOff();
                                }
                                else
                                {
                                    tempObj2.GetComponent<DrawlineScript>().lineRenderOn();
                                }
                            }
                        }
                        break;

                    default:

                        if (hit.transform.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
                        {
                            foreach (Material mat in hit.transform.gameObject.GetComponent<Renderer>().materials)
                                mat.color = Color.red;
                        }
                        else if (hit.transform.gameObject.GetComponent<Renderer>().material.color == Color.red)
                        {
                            foreach (Material mat in hit.transform.gameObject.GetComponent<Renderer>().materials)
                                mat.color = Color.white;
                        }
                        else
                        {
                            foreach (Material mat in hit.transform.gameObject.GetComponent<Renderer>().materials)
                                mat.color = Color.yellow;

                            mainGameObj.GetComponent<MainCharacterScript>().setUpTargetPoint(hit.transform);
                            mainGameObj.GetComponent<MainCharacterScript>().isMoving = true;
                            mainGameObj.GetComponent<MainCharacterScript>().PlayerMoving();
                            textMeshDescription.text = hit.transform.gameObject.GetComponent<BuildingScript>().Description;
                        }
                        break;
                }

                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);
                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("touchBegan", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("touchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }


                foreach (GameObject g in touchPrev)
                {
                    if (!touchList.Contains(g))
                        g.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
#endif
        if (Input.touchCount > 0)
        {
            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();


            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("RayCasting Detected.");
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("touchBegan", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("touchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            foreach (GameObject g in touchPrev)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

}
