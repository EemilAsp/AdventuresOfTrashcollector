using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{  

    [SerializeField] private AudioSource buttonClickSound;

    public void showGameOverScreen(){
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
