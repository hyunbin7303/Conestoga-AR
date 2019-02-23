using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTracer : MonoBehaviour
{

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchPrev;
    private RaycastHit hit;
    string btnName;

    // Music Information
    public AudioClip[] aClips;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000, Color.green, 10, false);
            if (Physics.Raycast(ray, out hit))
            {
                btnName = hit.transform.name;
                Debug.Log("btn Name is : " + btnName);
                switch (btnName)
                {
                    case "btn1":
                        audioSource.clip = aClips[0];
                        audioSource.Play();
                        break;
                    case "btn2":
                        audioSource.clip = aClips[1];
                        audioSource.Play();
                        break;
                    case "btn3":
                        audioSource.clip = aClips[2];
                        audioSource.Play();
                        break;
                    case "btn4":
                        audioSource.clip = aClips[3];
                        audioSource.Play();
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
                if(Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                if(Input.GetMouseButton(0))
                {
                    recipient.SendMessage("touchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }


                foreach(GameObject g in touchPrev)
                {
                    if (!touchList.Contains(g))
                        g.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
#endif
        if(Input.touchCount > 0)
        {
            touchPrev = new GameObject[touchList.Count];
            touchList.CopyTo(touchPrev);
            touchList.Clear();


            foreach(Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray, out hit))
                {
                    Debug.Log("RayCasting Detected.");
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if(touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("touchBegan", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if(touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("touchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if(touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            foreach(GameObject g in touchPrev)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("touchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }


        }

        

    }
}


// Once I've created my rayTracer script, I have to activate it by assigning it to one of the objects in the scene.
