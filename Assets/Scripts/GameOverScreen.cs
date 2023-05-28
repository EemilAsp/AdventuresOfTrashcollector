using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{  
    public string playerName;
    [SerializeField] private AudioSource buttonClickSound;

    public void showGameOverScreen(){
        playerName = PlayerPrefs.GetString("CurrentPlayerName");

        int highScore = PlayerPrefs.GetInt(playerName);
        int currentScore = PlayerPrefs.GetInt("CurrentSessionScore");

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(playerName, highScore);
        }
        PlayerPrefs.SetInt("CurrentSessionScore", 0);

        gameObject.SetActive(true);
        buttonClickSound.Play();
    }

    public void restartGameButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenuButton(){
        buttonClickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
