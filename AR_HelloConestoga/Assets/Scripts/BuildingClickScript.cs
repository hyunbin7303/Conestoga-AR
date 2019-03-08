using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClickScript : MonoBehaviour
{
    string buildingName;
    public string[] strBuildings;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                buildingName = hit.transform.name;
                Debug.Log("THE NAME OF THE BILIDING. : " + buildingName);
                switch (buildingName)
                {
                    case "MainBuilding":
                        Debug.Log("MAINBUILDING AANOUNCE.");
                        break;

                    case "WS":
                        Debug.Log("Wooodskill building clicked.");
                        break;
                    case "ATS":
                        Debug.Log("ATS BUILDING ANNOUNCE.");
                        break;
                    case "RecCentre":
                        Debug.Log("Rec Centre Announce.");
                        break;
                    default:
                        break;

                }
            }
        }



    }

    private void PrintName(GameObject gameObject)
    {
        print(gameObject.name);
    }
}
