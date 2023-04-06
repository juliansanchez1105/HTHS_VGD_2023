using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames = new List<Sprite>();
    private Image image;
    [SerializeField] private float delay = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter(){
        foreach(Sprite frame in frames){
            GetComponent<Image>().sprite = frame;
            yield return new WaitForSecondsRealtime(delay);
        }

        SceneManager.LoadScene(1);
    }

}
