using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VirtualButton_Adam : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vbBtnObj;
    public Animator cubeAni;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("Btn_AdamCar");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        cubeAni.GetComponent<Animator>();
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        cubeAni.Play("Cube_Animation");
        Debug.Log("Btn Pressed.");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        cubeAni.Play("NONE");
        Debug.Log("Btn Pressed.");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
