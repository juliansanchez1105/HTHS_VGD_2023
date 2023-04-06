using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private Sprite accessed;
    [SerializeField] private int levelNum;
    public void CardCollected(){
        card.GetComponent<Image>().sprite = accessed;
    }
    public int LevelNum{
        get{return levelNum;}
    }
}
