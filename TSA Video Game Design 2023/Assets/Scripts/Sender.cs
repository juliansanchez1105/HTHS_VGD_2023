using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sender : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    private List<string> levelNames = new List<string>();
    void Start(){
        foreach (GameObject level in levels){
            levelNames.Add(level.name);
        }
        for(int i = 0; i < AccessCards.CardsGotten.Count; i++){
            GameObject button = levels[levelNames.FindIndex(name => levelNames.Contains("Level " + AccessCards.CardsGotten[i]))];
            button.GetComponent<LevelButton>().CardCollected();
        }
    }
    public void LoadWorld(int num){
        SceneManager.LoadScene(num);
    }
}
