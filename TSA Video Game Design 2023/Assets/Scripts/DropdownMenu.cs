using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class addFunction : MonoBehaviour
{
    [SerializeField] private GameObject dropdown;
    int m_DropdownValue; //index


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void add()
    {
        m_DropdownValue = dropdown.GetComponent<Dropdown>().value;
        Debug.Log("Dropdown Value : " + m_DropdownValue);
    }
}
