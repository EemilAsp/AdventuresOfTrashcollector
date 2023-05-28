using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{

    [SerializeField] private AudioSource teleportEffect;
    [SerializeField] private CollectorScript CollectorScript;
    public string playerName;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            CollectorScript.savePlayerScore();
            if(SceneManager.GetActiveScene().name == "Level_1")
            {
                teleportEffect.Play();
                SceneManager.LoadScene("Level_2");
            }else if(SceneManager.GetActiveScene().name == "Level_2")
            {
                teleportEffect.Play();
                SceneManager.LoadScene("Level_3");
            }else if(SceneManager.GetActiveScene().name == "Level_3")
            {
                teleportEffect.Play();
                SceneManager.LoadScene("Final_Boss");
            }else{
                teleportEffect.Play();
                SceneManager.LoadScene("CreditsScene");
                playerName = PlayerPrefs.GetString("CurrentPlayerName");

                int highScore = PlayerPrefs.GetInt(playerName);
                int currentScore = PlayerPrefs.GetInt("CurrentSessionScore");
                if (currentScore > highScore)
                {
                    highScore = currentScore;
                    PlayerPrefs.SetInt(playerName, highScore);
                }
                PlayerPrefs.SetInt("CurrentSessionScore", 0);
                
            }
            
        }
    }

}
