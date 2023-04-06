using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILine
{
    float DomainStart {set; get;}
    float DomainEnd {set; get;}
    void UpdateParams();
    void MakeLine();
}
