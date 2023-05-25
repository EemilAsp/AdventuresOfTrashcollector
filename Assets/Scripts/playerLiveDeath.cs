using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLiveDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthBar;
    public int maxScores = 10;
    public string PlayerName;
    private Animator playerAnim;
    private Rigidbody2D playerRB;
    public Animator healthBarAnim;
    [SerializeField] public Text gameOverScoreText;
    private enum HealthBarState {full, mid, low, empty}
    public CollectorScript CollectorScript;
    public GameOverScreen GameOverScreen;
    public PlayerMovement PlayerMovement;

    [SerializeField] private AudioSource lavaDeathSound;
    [SerializeField] private AudioSource dyingSound;
    [SerializeField] private AudioSource damageSound;

    private List<HighScoreEntry> highScores = new List<HighScoreEntry>();

    [System.Serializable]
    public class HighScoreEntry
    {
        public string playerName;
        public int score;
    }


    void Start()
    {
        LoadHighScores();
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        healthBar = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("npc_monster"))
        {
            if((healthBar - 1) <= 0){
                //Player dies if healthbar = 0
                healthBar -= 1;
                updateHealthBarAnimation();
                death();
            }else{
                //else 1 less healthbar
                damageSound.Play();
                playerAnim.SetTrigger("damage_Trigger");
                healthBar -= 1;
                updateHealthBarAnimation();
            }
        }
        if(collision.gameObject.CompareTag("lavaTrap")){
            lavaDeathSound.Play();
            healthBar = 0;
            updateHealthBarAnimation();
            death();
        }
    }

    private void death(){
        dyingSound.Play();
        playerRB.bodyType = RigidbodyType2D.Static;
        playerAnim.SetTrigger("death_Trigger");
        PlayerMovement.setAliveFalse();
    }


    private void updateHealthBarAnimation(){
        HealthBarState health_State;
        if(healthBar == 3){
            health_State = HealthBarState.full;
        }else if(healthBar == 2){
            health_State = HealthBarState.mid;
        }else if(healthBar == 1){
            health_State = HealthBarState.low;
        }else{
            health_State = HealthBarState.empty;
        }
        healthBarAnim.SetInteger("health_State", (int)health_State);
    }

    private void callGameOver(){
        int score = CollectorScript.getPlayerScore();
        gameOverScoreText.text = "Score: "+ score;
        PlayerName = PlayerPrefs.GetString("CurrentPlayerName");
        AddHighScore(PlayerName, score);
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);

        GameOverScreen.showGameOverScreen();
    }



    void LoadHighScores()
    {
        // Load high scores from PlayerPrefs or a file
        for (int i = 0; i < maxScores; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName" + i);
            int score = PlayerPrefs.GetInt("PlayerScore" + i);
            highScores.Add(new HighScoreEntry { playerName = playerName, score = score });
        }
    }

    void SaveHighScores()
    {
        // Save high scores to PlayerPrefs or a file
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, highScores[i].playerName);
            PlayerPrefs.SetInt("PlayerScore" + i, highScores[i].score);
        }
    }


    public void AddHighScore(string playerName, int score)
    {
        highScores.Add(new HighScoreEntry { playerName = playerName, score = score });
        highScores.Sort((a, b) => b.score.CompareTo(a.score)); // Sort in descending order

        if (highScores.Count > maxScores)
        {
            highScores.RemoveAt(maxScores); // Remove the lowest score
        }

        SaveHighScores();
    }
}
