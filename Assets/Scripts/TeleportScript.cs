using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{

    [SerializeField] private AudioSource teleportEffect;
    [SerializeField] private CollectorScript CollectorScript;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            teleportEffect.Play();
            CollectorScript.savePlayerScore();
            if(SceneManager.GetActiveScene().name == "Level_1")
            {
                
                SceneManager.LoadScene("Level_2");
            }else if(SceneManager.GetActiveScene().name == "Level_2")
            {
                SceneManager.LoadScene("Level_3");
            }else if(SceneManager.GetActiveScene().name == "Level_3")
            {
                //SceneManager.LoadScene("Final_Boss");
            }else{
                SceneManager.LoadScene("CreditsScene");
            }
            
        }
    }

}
