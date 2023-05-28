using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 1f;
    public Transform[] points;
    public int destination;
    public AudioSource damageSound;
    public AudioSource dyingSound;
    public GameObject teleport;
    
    // Update is called once per frame
    void Update()
    {
        if(destination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, points[0].position) < 4f)
            {
                flipAnim();
                destination = 1;
            }
        }
        if(destination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, points[1].position) < 4f)
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

    public void moreSpeed(){
        moveSpeed *= 1.25f;
    }

    public void DamageSound(){
        damageSound.Play();
    }

    public void destroyFinalBoss(){
        dyingSound.Play();
        teleport.SetActive(true);
        Destroy(gameObject);
    }

    
}
