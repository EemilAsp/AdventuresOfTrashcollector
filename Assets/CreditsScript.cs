using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsScript : MonoBehaviour
{

    [SerializeField] private AudioSource buttonClickSound;
    
    public void backToMainMenu(){
        buttonClickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
