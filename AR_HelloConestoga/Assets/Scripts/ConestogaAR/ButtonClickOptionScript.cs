
using UnityEngine;

public class ButtonClickOptionScript : MonoBehaviour
{
    public GameObject ATCbuilding;
    public GameObject WSbuilding;
    public GameObject Mainbuilding;
    public GameObject RecreationCentrebuilding;
    public GameObject WelcomeCentrebuilding;
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    string btnNameStr;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ATS()
    {
        if (ATCbuilding.GetComponent<Renderer>().material.color == Color.red)
            ATCbuilding.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            ATCbuilding.GetComponent<Renderer>().material.color = Color.red;
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
    }
    public void Woodskill()
    {
        if(WSbuilding.GetComponent<Renderer>().material.color == Color.blue)
            WSbuilding.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            WSbuilding.GetComponent<Renderer>().material.color = Color.blue;
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }
    public void MailDoonBuilding()
    {
        if (Mainbuilding.GetComponent<Renderer>().material.color == Color.yellow)
            Mainbuilding.GetComponent<Renderer>().material.color = Color.white;
        else
            Mainbuilding.GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void RecreationCentre()
    {
        if (RecreationCentrebuilding.GetComponent<Renderer>().material.color == Color.green)
            RecreationCentrebuilding.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            RecreationCentrebuilding.GetComponent<Renderer>().material.color = Color.green;
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
    }
    public void WelcomeCentre()
    {
        if(WelcomeCentrebuilding.GetComponent<Renderer>().material.color == Color.cyan)
        {
            foreach (Material mat in WelcomeCentrebuilding.transform.gameObject.GetComponent<Renderer>().materials)
                mat.color = Color.white;
        }
        else
        {
            foreach (Material mat in WelcomeCentrebuilding.transform.gameObject.GetComponent<Renderer>().materials)
                mat.color = Color.cyan;
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
    }
}
