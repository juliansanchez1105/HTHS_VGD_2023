using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sender : MonoBehaviour
{
    public void LoadWorld(int num){
        SceneManager.LoadScene(num);
    }
}
