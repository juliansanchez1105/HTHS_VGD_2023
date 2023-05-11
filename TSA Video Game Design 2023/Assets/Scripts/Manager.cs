using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject worldObjects;
    private List<GameObject> worldList = new List<GameObject>();
    private int indexActive;
    [SerializeField] private GameObject LeftWorld;
    [SerializeField] private GameObject RightWorld;
    [SerializeField] private GameObject worldBackgrounds;
    private List<GameObject> bgList = new List<GameObject>();
    [SerializeField] private GameObject MissionComplete;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(worldObjects);
        for(int i = 0; i < worldObjects.transform.childCount; i++)
        {
            //Debug.Log(worldObjects.transform.GetChild(i).gameObject);
            worldList.Add(worldObjects.transform.GetChild(i).gameObject);
            bgList.Add(worldBackgrounds.transform.GetChild(i).gameObject);
            if(i != 0)
            {
                worldList[i].SetActive(false);
                bgList[i].SetActive(false);
            }
        }
        indexActive = 0;

        LeftWorld.SetActive(false);

        RightWorld.GetComponent<Image>().sprite = worldList[indexActive + 1].GetComponent<Image>().sprite;

        Vector4 color = worldList[indexActive + 1].GetComponent<Image>().color;
        RightWorld.GetComponent<Image>().color = new Color(color[0], color[1], color[2], 40);

    }

    void OnEnable(){
        int count = 0;
        for(int i = 1; i <= AccessCards.Cards.Count; i++){
            if(AccessCards.Cards[i]){
                count++;
            }
        }

        if(count >= 8){
            MissionComplete.SetActive(true);
        }
    }

    public void LoadWorld(int num){
        SceneManager.LoadScene(num);

    }

    public void LoadAux(string name){
        SceneManager.LoadScene(name);
    }

    public void shiftLeft()
    {
        if(indexActive > 0)
        {
            worldList[indexActive].SetActive(false);
            worldList[indexActive - 1].SetActive(true);

            bgList[indexActive].SetActive(false);
            bgList[indexActive - 1].SetActive(true);
            
            if(indexActive > 1){
                LeftWorld.GetComponent<Image>().sprite = worldList[indexActive - 2].GetComponent<Image>().sprite;

                Vector4 colorLeft = worldList[indexActive - 2].GetComponent<Image>().color;
                LeftWorld.GetComponent<Image>().color = new Color(colorLeft[0], colorLeft[1], colorLeft[2], 40);
            }
            else{
                LeftWorld.SetActive(false);
            }

            RightWorld.SetActive(true);
            RightWorld.GetComponent<Image>().sprite = worldList[indexActive].GetComponent<Image>().sprite;

            Vector4 colorRight = worldList[indexActive].GetComponent<Image>().color;
            RightWorld.GetComponent<Image>().color = new Color(colorRight[0], colorRight[1], colorRight[2], 40);

            indexActive -= 1;
        }
    }

    public void shiftRight()
    {
        if(indexActive < worldList.Count - 1)
        {
            worldList[indexActive].SetActive(false);
            worldList[indexActive + 1].SetActive(true);

            bgList[indexActive].SetActive(false);
            bgList[indexActive + 1].SetActive(true);
            
            if(indexActive < worldList.Count - 2){
                RightWorld.GetComponent<Image>().sprite = worldList[indexActive + 2].GetComponent<Image>().sprite;

                Vector4 colorRight = worldList[indexActive + 2].GetComponent<Image>().color;
                RightWorld.GetComponent<Image>().color = new Color(colorRight[0], colorRight[1], colorRight[2], 40);
            }
            else{
                RightWorld.SetActive(false);
            }

            LeftWorld.SetActive(true);
            LeftWorld.GetComponent<Image>().sprite = worldList[indexActive].GetComponent<Image>().sprite;

            Vector4 colorLeft = worldList[indexActive].GetComponent<Image>().color;
            LeftWorld.GetComponent<Image>().color = new Color(colorLeft[0], colorLeft[1], colorLeft[2], 40);

            indexActive += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
