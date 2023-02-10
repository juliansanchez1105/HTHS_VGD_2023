using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneKaren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
    }

    public void LoadWorld(int num){
        Debug.Log("loading world 1");
        SceneManager.LoadScene(num);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
