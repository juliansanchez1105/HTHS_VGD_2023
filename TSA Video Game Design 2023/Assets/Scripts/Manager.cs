using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject worldObjects;
    private List<GameObject> worldList = new List<GameObject>();
    private int indexActive;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(worldObjects);
        for(int i = 0; i < worldObjects.transform.childCount; i++)
        {
            //Debug.Log(worldObjects.transform.GetChild(i).gameObject);
            worldList.Add(worldObjects.transform.GetChild(i).gameObject);
            if(i != 0)
            {
                worldList[i].SetActive(false);
            }
        }
        indexActive = 0;

    }

    public void LoadWorld(int num){
        Debug.Log("loading world 1");
        SceneManager.LoadScene(num);

    }

    public void shiftLeft()
    {
        if(indexActive > 0)
        {
            worldList[indexActive].SetActive(false);
            worldList[indexActive - 1].SetActive(true);
            indexActive -= 1;
        }
    }

    public void shiftRight()
    {
        if(indexActive < worldList.Count - 1)
        {
            worldList[indexActive].SetActive(false);
            worldList[indexActive + 1].SetActive(true);
            indexActive += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
