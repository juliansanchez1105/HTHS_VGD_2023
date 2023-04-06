using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOff : MonoBehaviour
{
    public void TurnSoundOff(){
        AudioListener.pause = !AudioListener.pause;
    }
}
