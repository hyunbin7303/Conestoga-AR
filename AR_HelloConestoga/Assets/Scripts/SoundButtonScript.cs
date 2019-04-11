// Source from https://www.youtube.com/watch?v=TOq3DpoPygo



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonScript : MonoBehaviour
{
    public AudioClip[] aClips;
    public AudioSource audioSource;
    string btnName;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("BTN NAME: " + btnName);

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;
                switch(btnName)
                {
                    case "myButton1":
                        audioSource.clip = aClips[0];
                        audioSource.Play();
                        break;
                    case "myButton2":
                        audioSource.clip = aClips[1];
                        audioSource.Play();
                        break;
                    case "myButton3":
                        audioSource.clip = aClips[2];
                        audioSource.Play();
                        break;
                    case "myButton4":
                        audioSource.clip = aClips[3];
                        audioSource.Play();
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}
