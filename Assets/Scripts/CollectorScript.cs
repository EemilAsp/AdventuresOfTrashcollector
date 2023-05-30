using System.Security.AccessControl;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public static int trashCollected;
    public string playerName;
    [SerializeField] public Text trashCount;
    [SerializeField] private AudioSource collectSound;

    void Start(){
        playerName = PlayerPrefs.GetString("CurrentPlayerName"); // keep the score between levels
        trashCollected = PlayerPrefs.GetInt("CurrentSessionScore"); // keep the score between levels
        trashCount.text = "Trash collected: "+ trashCollected; // set text to ui
    }

     public int getPlayerScore(){
        savePlayerScore();
        return(trashCollected);
    }

    public void savePlayerScore(){
        PlayerPrefs.SetInt("CurrentSessionScore", trashCollected);
    }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("collectable"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            trashCollected += 1;
            trashCount.text = "Trash collected: "+ trashCollected;
        }
    }

   
