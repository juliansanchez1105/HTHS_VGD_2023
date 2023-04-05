using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private Sprite accessed;
    public void CardCollected(){
        card.GetComponent<Image>().sprite = accessed;
    }
}
