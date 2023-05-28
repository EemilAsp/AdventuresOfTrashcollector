using System.Security.Cryptography.X509Certificates;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashBagScript : MonoBehaviour
{
    public AudioSource collectSound;
    public GameObject npcEnemy;
    public GameObject WasteBag;
    public float scaleMultiplier = 0.25f;
    private bossBehaviour npcScripts;

    private void Start()
    {
        npcEnemy = GameObject.FindWithTag("npc_monster");
        npcScripts = npcEnemy.GetComponent<bossBehaviour>();
        collectSound = WasteBag.GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            collectSound.Play();
            if (npcEnemy != null && !ReferenceEquals(npcEnemy, null)){
                npcEnemy.transform.localScale *= scaleMultiplier;
                npcScripts.moreSpeed();
                npcScripts.DamageSound();
                if (npcEnemy.transform.localScale.x < 5f && npcEnemy.transform.localScale.y < 5f)
                    {
                        npcScripts.destroyFinalBoss();
                    }
            }
            Destroy(WasteBag);  
        }
    }

}
