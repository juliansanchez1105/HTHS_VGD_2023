using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource src;
    public AudioClip Bounce, Break, Button, Collision, Electric, Fry, Key, Laser, Launcher, Music, Switch;

    public void PlayBounce(){
        src.clip = Bounce;
        src.Play()
    }

    public void PlayBreak(){
        src.clip = Break;
        src.Play();
    }

    public void PlayButton(){
        src.clip = Button;
        src.Play();
    }

    public void PlayCollision(){
        src.clip = Collision;
        src.Play();
    }

    public void PlayElectric(){
        src.clip = Electric;
        src.Play();
    }

    public void PlayFry(){
        src.clip = Fry;
        src.Play();
    }

    public void PlayKey(){
        src.clip = Key;
        src.Play();
    }

    public void PlayLaser(){
        src.clip = Laser;
        src.Play();
    }

    public void PlayLauncher(){
        src.clip = Launcher;
        src.Play();
    }

    public void PlayMusic(){
        src.clip = Music;
        src.Play();
    }

    public void PlaySwitch(){
        src.clip = Switch;
        src.Play();
    }
}
