using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class Domain : MonoBehaviour
{
    [SerializeField] private TMP_InputField domainStart;
    [SerializeField] private TMP_InputField domainEnd;
    [SerializeField] private GameObject slot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDomain(){
        //Debug.Log(domainStart.text);
        float start = float.Parse(domainStart.text, CultureInfo.InvariantCulture.NumberFormat);
        float end = float.Parse(domainEnd.text, CultureInfo.InvariantCulture.NumberFormat);

        if(slot.GetComponentInChildren<Line>().LineType.TryGetComponent(out ILine component)){
            component.DomainStart = start;
            domainStart.text = component.DomainStart.ToString();
            component.DomainEnd = end;
            domainEnd.text = component.DomainEnd.ToString();
        }
        else{
            Debug.Log("Failed to update Domain.");
        }
    }
}
