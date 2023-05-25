using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private AudioSource buttonClickSound;
    [SerializeField] private GameObject HighScoreScreen;
    [SerializeField] private GameObject LevelsScreen;
    [SerializeField] private GameObject MainMenuScreen;

    public void startGameButton(){
        buttonClickSound.Play();
        MainMenuScreen.SetActive(true);
        SceneManager.LoadScene("Level_1");
    }
    
    public void highScoreButton(){
        buttonClickSound.Play();
        MainMenuScreen.SetActive(false);
        HighScoreScreen.SetActive(true);

    }

    public void showLevelsButton(){
        buttonClickSound.Play();
        LevelsScreen.SetActive(true);
        MainMenuScreen.SetActive(false);
    }

    public void backToMainMenu(){
        buttonClickSound.Play();
        LevelsScreen.SetActive(false);
        HighScoreScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
    }

    public void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void creditsButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene("CreditsScene");
    }

    public void cityLevelButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene("Level_1");
    }

    public void ParkLevelButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene("Level_2");
    }
    


}
