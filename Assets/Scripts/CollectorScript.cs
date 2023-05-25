using System.Security.AccessControl;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int itemsCollected;
    [SerializeField] public Text trashCount;
    [SerializeField] private AudioSource collectSound;

    void Start(){
        itemsCollected = PlayerPrefs.GetInt("CurrentPlayerScore");
        trashCount.text = "Trash collected: "+ itemsCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("collectable"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            itemsCollected += 1;
            trashCount.text = "Trash collected: "+ itemsCollected;
        }
    }

    public int getPlayerScore(){
        savePlayerScore();
        return(itemsCollected);
    }

    public void savePlayerScore(){
        PlayerPrefs.SetInt("CurrentPlayerScore", itemsCollected);
    }
}
