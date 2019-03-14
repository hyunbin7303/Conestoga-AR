using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClickScript : MonoBehaviour
{
    string buildingName;
    public string[] strBuildings;
    // Update is called once per frame

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchPrev;
    private RaycastHit hit;
    private GameObject lineObj_MainToRec;
    private void Start()
    {

    }
    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000, Color.green, 10, false);
            if (Physics.Raycast(ray, out hit))
            {
                buildingName = hit.transform.name;
                Debug.Log("btn Name is : " + buildingName);
                switch (buildingName)
                {
                    case "Loc_RecCentre":
                        if (GameObject.Find("Line_main_rec").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_rec");
                            tempObj.GetComponent<DrawlineScript>().lineRenderOn();
                        }
                        break;

                    case "Loc_ATC":
                        if (GameObject.Find("Line_main_ATC").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_ATC");
                            tempObj.GetComponent<DrawlineScript>().lineRenderOn();
                        }
                        break;
                    case "Loc_WelcomeCentre":
                        if (GameObject.Find("Line_main_WelcomeCentre").name != null)
                        {
                            GameObject tempObj = GameObject.Find("Line_main_WelcomeCentre");
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
                                tempObj2.GetComponent<DrawlineScript>().lineRenderOn();
                            }
                        }
                        break;
                    default:
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
