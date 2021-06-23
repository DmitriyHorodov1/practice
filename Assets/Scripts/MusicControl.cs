using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    public Button on;
    public Button off;
    bool check;
    private void Start()
    {
        on.gameObject.SetActive(false);
        off.gameObject.SetActive(true);
        check = true;
    }

    public void MusicOn()
    {
       
            Mixer.audioMixer.SetFloat("Music", 0);
        check = true;

    }
    public void MusicOff()
    {
        Mixer.audioMixer.SetFloat("Music", -80);
        check = false;
    }
    public void Update()
    {
        if(check == true)
        {
            on.gameObject.SetActive(false);
            off.gameObject.SetActive(true);

        }
        else
        {
            on.gameObject.SetActive(true);
            off.gameObject.SetActive(false);



        }
    }

}
