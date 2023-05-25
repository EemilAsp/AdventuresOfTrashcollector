using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsScript : MonoBehaviour
{
    
    [SerializeField] public GameObject settingsScreen;
    [SerializeField] private AudioSource buttonClickSound;

    public void showSettingsScreen(){
        settingsScreen.SetActive(true);
        buttonClickSound.Play();
    }

}
