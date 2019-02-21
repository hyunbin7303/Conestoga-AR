// Referring to the material of the cube object as "mat".
// Source from :https://gamedevelopment.tutsplus.com/tutorials/introduction-to-vuforia-on-unity-for-creating-augmented-reality-applications--cms-27693


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static Color defaultColor;
    public static Color selectedColor;
    public static Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusDstAlpha);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;

        defaultColor = new Color32(255, 255, 255, 255);
        selectedColor = new Color32(255, 0, 0, 255);
        mat.color = defaultColor;
        
    }
    // Used for calling at the instance I touched on the ebject.
    void touchBegan()
    {
        mat.color = selectedColor;
    }

    //Called when Irealease my finger.
    void touchEnded()
    {
        mat.color = defaultColor;
    }
    // called right after I touched on the object.
    void touchStay()
    {
        mat.color = selectedColor;
    }

    void touchExit()
    {
        mat.color = defaultColor;
    }
}
