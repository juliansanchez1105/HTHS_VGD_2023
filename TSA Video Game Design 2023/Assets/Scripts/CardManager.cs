using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    [SerializeField] private Sprite granted;
    void OnEnable(){
        foreach(GameObject level in levels){
            if(AccessCards.Cards[level.GetComponent<LevelButton>().LevelNum]){
                Debug.Log("Granted");
                level.transform.GetChild(1).GetComponent<Image>().sprite = granted;
            }
        }
    }
}
