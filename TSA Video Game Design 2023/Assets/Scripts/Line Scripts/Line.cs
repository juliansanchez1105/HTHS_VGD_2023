using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject lineType;
    // Start is called before the first frame update
    void Start()
    {
        LineActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LineActive(bool onOff){
        lineType.SetActive(onOff);
    }
}
