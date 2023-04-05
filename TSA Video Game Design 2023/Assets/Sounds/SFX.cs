using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource Bounce;
    public AudioSource Break;
    public AudioSource Button;
    public AudioSource Collision;
    public AudioSource Electric;
    public AudioSource Fry;
    public AudioSource Key;
    public AudioSource Laser;
    public AudioSource Launcher;
    public AudioSource Music;
    public AudioSource Switch;

    public void PlayBounce(){
        Bounce.Play();
    }

    public void PlayBreak(){
        Break.Play();
    }

    public void PlayButton(){
        Button.Play();
    }

    public void PlayCollision(){
        Collision.Play();
    }

    public void PlayElectric(){
        Electric.Play();
    }

    public void PlayFry(){
        Fry.Play();
    }

    public void PlayKey(){
        Key.Play();
    }

    public void PlayLaser(){
        Laser.Play();
    }

    public void PlayLauncher(){
        Launcher.Play();
    }

    public void PlayMusic(){
        Music.Play();
    }

    public void PlaySwitch(){
        Switch.Play();
    }
}
