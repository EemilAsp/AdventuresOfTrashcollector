using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    [SerializeField] private AudioSource drinkSound;
    [SerializeField] private Animator canAnimator;
    [SerializeField] PlayerMovement PlayerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            drinkSound.Play();
            canAnimator.SetBool("Collected", true);
            PlayerMovement.setBoosted();
        }
    }

    public void destroyCan(){
        Destroy(gameObject);
    }

}
