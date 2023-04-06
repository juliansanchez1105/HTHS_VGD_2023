using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCards : MonoBehaviour
{
    private static Dictionary<int, bool> cards = new Dictionary<int, bool>();
    private static int levelCount = 16;
    // Start is called before the first frame update

    static AccessCards(){
        for(int i = 1; i <= levelCount; i++){
            cards[i] = false;
        }
    }
    public static Dictionary<int, bool> Cards{
        get{return cards;}
    }

    public static void SetCardTrue(int level){
        cards[level] = true;
        Debug.Log(cards);
    }
}
