using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material[] BodyColorMat;
    Material CurrMat;
    Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
    }
    public void RedColor()
    {
        renderer.material = BodyColorMat[0];
        CurrMat = renderer.material;
    }
    public void BlueColor()
    {
        renderer.material = BodyColorMat[1];
        CurrMat = renderer.material;
    }
    public void YellowColor()
    {
        renderer.material = BodyColorMat[2];
        CurrMat = renderer.material;
    }
    public void GreenColor()
    {
        renderer.material = BodyColorMat[3];
        CurrMat = renderer.material;
    }
    public void OrangeColor()
    {
        renderer.material = BodyColorMat[4];
        CurrMat = renderer.material;
    }

}
