using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] private BoxCollider2D left;
    [SerializeField] private BoxCollider2D right;
    [SerializeField] private BoxCollider2D top;
    [SerializeField] private BoxCollider2D bottom;
    [SerializeField] private Ball ball;
    // Start is called before the first frame update
    void OnEnable()
    {
        MakeBorders();
    }

    public void MakeBorders(){
        left.gameObject.transform.position = new Vector3(-1 * ball.DeathValX - 0.5f, 0, 0);
        right.gameObject.transform.position = new Vector3(ball.DeathValX + 0.5f, 0, 0);
        top.gameObject.transform.position = new Vector3(0, ball.DeathValY + 0.5f, 0);
        bottom.gameObject.transform.position = new Vector3(0, -1 * ball.DeathValY - 0.5f, 0);


        left.size = new Vector2(1, 2 * ball.DeathValY);
        right.size = new Vector2(1, 2 * ball.DeathValY);
        top.size = new Vector2(2 * ball.DeathValX, 1);
        bottom.size = new Vector2(2 * ball.DeathValX, 1);
    }

}
