using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatePlayerScript : MonoBehaviour
{
    public InputField inputField;
    public GameObject errorScreen;
    public GameObject playercreateScreen;
    public Button submitButton;
    private float timerDuration = 2f;
    private bool timerRunning = false;
    public string userName;

    private void Start()
    {
        submitButton.onClick.AddListener(onCreatePlayer);
    }

    public void onCreatePlayer()
    {
        userName = inputField.text;
        UnityEngine.Debug.Log(userName);
        if (string.IsNullOrEmpty(userName))
        {
            ShowErrorScreen();
        }else{
            PlayerPrefs.SetString("CurrentPlayerName", userName);
            PlayerPrefs.SetInt("CurrentSessionScore", 0);
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void ShowErrorScreen()
    {
        errorScreen.SetActive(true);
        StartTimer();
    }

    private void HideErrorScreen()
    {
        errorScreen.SetActive(false);
    }

    private void StartTimer()
    {
        timerRunning = true;
        timerDuration = 2f;
    }

    private void Update()
    {
        if (timerRunning)
        {
            timerDuration -= Time.deltaTime;

            if (timerDuration <= 0f)
            {
                HideErrorScreen();
                timerRunning = false;
            }
        }
    }
}
