using System.Collections;
using UnityEngine;

public class bossBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform[] points;
    public int destination;
    public AudioSource damageSound;
    public AudioSource dyingSound;
    public GameObject teleport;
    public projectileShooter projectileShooter;
    public Animator npcanim;
    private bool alive;

    void Start()
    {
        alive = true;
        npcanim = GetComponent<Animator>();
    }

    void Update()
    {
        if (alive){
        if (transform.localScale.x < 5f && transform.localScale.y < 5f)
        {
            alive = false;
            destroyFinalBoss();
        }
        else
        {
            
            
                if (destination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, points[0].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, points[0].position) < 4f)
                    {
                        flipAnim();
                        destination = 1;
                    }
                }
                if (destination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, points[1].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, points[1].position) < 4f)
                    {
                        flipAnim();
                        destination = 0;
                    }
                }
            }
        }
    }

    private void flipAnim()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void moreSpeed()
    {
        moveSpeed *= 1.25f;
    }

    public void DamageSound()
    {
        if(alive){
        damageSound.Play();
        npcanim.SetBool("DamageTaken", true);
        }
    }

    public void destroyFinalBoss()
    {
        resetTrigger();
        projectileShooter.setAliveFalse();
        dyingSound.Play();
        npcanim.SetTrigger("BossDead");
        teleport.SetActive(true);
    }

    public void resetTrigger()
    {
        npcanim.SetBool("DamageTaken", false);
    }

    public void destroyBoss()
    {
        Destroy(gameObject);
    }
}
