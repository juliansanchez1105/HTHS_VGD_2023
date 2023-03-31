using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class addFunction : MonoBehaviour
{
    //string m_Message;
    //public Text m_Text;
    [SerializeField] private TMPro.TMP_Dropdown dropdown;
    private int m_DropdownValue; //index
    private string functionType;


    // Start is called before the first frame update
    void Start()
    {
        //m_Dropdown = GetComponent<Dropdown>();
        //Debug.Log("Starting Dropdown Value : " + m_Dropdown.value); 
        //Debug.Log("Starting Dropdown Value : " + m_Dropdown.value); 
    }

    public void add()
    {
        m_DropdownValue = dropdown.GetComponent<TMP_Dropdown>().value;
        Debug.Log("Dropdown Value : " + m_DropdownValue); 
        //m_Message = m_Dropdown.options[m_DropdownValue].text;
        //m_Text.text = m_Message;

        functionType = dropdown.GetComponent<TMP_Dropdown>().options[m_DropdownValue].text;
        Debug.Log("Function Type: " + functionType);
    }
}
