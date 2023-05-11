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
        //get{return new Dictionary<int, bool>(){{1, true}, {2, true}, {3, true}, {4, true}, {5, true}, {6, true}, {7, true}, {8, true}};}
    }

    public static void SetCardTrue(int level){
        cards[level] = true;
        Debug.Log(cards);
    }
}
