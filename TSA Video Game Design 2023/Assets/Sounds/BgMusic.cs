using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{

    public AudioSource src;
    public AudioClip Music;

    void Awake(){
        DontDestroyOnLoad(src);
        src.clip = Music;
        src.loop = true;
        src.Play();
    }

    public void PlayMusic()
    {
        
    }
}
