using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCards : MonoBehaviour
{
    private static List<int> cardsGotten = new List<int>();
    // Start is called before the first frame update

    public static List<int> CardsGotten{
        get{return cardsGotten;}
    }

    public static void SetCardTrue(int level){
        cardsGotten.Add(level);
    }
}
