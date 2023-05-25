using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreenScript : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;

    public void restartGameButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenuButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void hideSettingsScreen(){
        buttonClickSound.Play();
        gameObject.SetActive(false);
    }

}
