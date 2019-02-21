using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VB_RotateSquare : MonoBehaviour, IVirtualButtonEventHandler
{

    VirtualButtonBehaviour[] virtualButtonBehaviours;
    public GameObject vnBtnObj;
    public Animator cubeAni;
    public string vbName;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        vbName = vb.VirtualButtonName;
        if(vbName == "VirtualButtonChange")
        {
            VirtualButtonChange();
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //       vnBtnObj = GameObject.Find("")
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
        {
            virtualButtonBehaviours[i].RegisterEventHandler(this);
        }
    }


    void VirtualButtonChange()
    {

    }
}
