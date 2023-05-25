using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 1f;
    public Transform[] points;
    public int destination;
    
    // Update is called once per frame
    void Update()
    {
        if(destination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, points[0].position) < 0.2f)
            {
                flipAnim();
                destination = 1;
            }
        }
        if(destination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, points[1].position) < 0.2f)
            {
                flipAnim();
                destination = 0;
            }
        }
    }

    private void flipAnim(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    
}
