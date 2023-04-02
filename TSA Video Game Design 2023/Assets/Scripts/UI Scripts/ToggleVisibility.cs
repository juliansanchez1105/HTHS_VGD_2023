using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TurnOff(){
        gameObject.SetActive(false);
    }
}
