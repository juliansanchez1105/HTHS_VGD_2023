using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negation : MonoBehaviour
{
    private Vector2 topLeft;
    private Vector2 bottomRight;
    // Start is called before the first frame update
    void Start()
    {
        topLeft = new Vector2(transform.position.x - 0.5f * GetComponent<SpriteRenderer>().size.x, transform.position.y + 0.5f * GetComponent<SpriteRenderer>().size.y);
        bottomRight = new Vector2(transform.position.x + 0.5f * GetComponent<SpriteRenderer>().size.x, transform.position.y - 0.5f * GetComponent<SpriteRenderer>().size.y);
        //Debug.Log(topLeft);
        //Debug.Log(bottomRight);
    }

    public Vector2 TopLeft{
        get{return topLeft;}
    }
    public Vector2 BottomRight{
        get{return bottomRight;}
    }
}
