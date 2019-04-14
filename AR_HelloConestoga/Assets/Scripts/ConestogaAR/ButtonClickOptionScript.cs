
using UnityEngine;

public class ButtonClickOptionScript : MonoBehaviour
{
    public GameObject ATCbuilding;
    public GameObject WSbuilding;
    public GameObject Mainbuilding;
    public GameObject RecreationCentrebuilding;
    public GameObject WelcomeCentrebuilding;
    public AudioClip[] audioClips_Title;
    public AudioClip[] audioClips_Description;
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
            ATS_Sound();
        }
    }
    public void Woodskill()
    {
        if(WSbuilding.GetComponent<Renderer>().material.color == Color.blue)
            WSbuilding.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            WSbuilding.GetComponent<Renderer>().material.color = Color.blue;
            Woodskill_Sound();
        }
    }
    public void MailDoonBuilding()
    {
        if (Mainbuilding.GetComponent<Renderer>().material.color == Color.yellow)
            Mainbuilding.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            Mainbuilding.GetComponent<Renderer>().material.color = Color.yellow;
            MainBuilding_Sound();
        }
    }
    public void RecreationCentre()
    {
        if (RecreationCentrebuilding.GetComponent<Renderer>().material.color == Color.green)
            RecreationCentrebuilding.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            RecreationCentrebuilding.GetComponent<Renderer>().material.color = Color.green;
            RecreationCentre_Sound();
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
            WlecomeCentre_Sound();
        }
    }

    public void ATS_Sound()
    {
        audioSource.clip = audioClips_Title[0];
        audioSource.Play();
    }
    public void Woodskill_Sound()
    {
        audioSource.clip = audioClips_Title[1];
        audioSource.Play();
    }
    public void MainBuilding_Sound()
    {
        audioSource.clip = audioClips_Title[2];
        audioSource.Play();
    }
    public void RecreationCentre_Sound()
    {
        audioSource.clip = audioClips_Title[3];
        audioSource.Play();
    }
    public void WlecomeCentre_Sound()
    {
        audioSource.clip = audioClips_Title[4];
        audioSource.Play();
    }

    public void SoundOff()
    {
        // Used for turning off all sounds. 
    }
    public void SoundOn(Building building)
    {
        audioSource.clip = audioClips_Title[(int)building];
        audioSource.Play();
    }
    public void SoundOnDescription(Building building)
    {
        audioSource.clip = audioClips_Description[(int)building];
        audioSource.Play();
    }
    public void SoundWholeDescription()
    {
        audioSource.clip = audioClips_Title[5];
        audioSource.Play();
    }
}
