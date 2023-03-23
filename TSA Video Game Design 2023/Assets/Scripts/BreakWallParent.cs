using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallParent : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    // Start is called before the first frame update

    public void Respawn(){
        wall.SetActive(true);
    }
}
