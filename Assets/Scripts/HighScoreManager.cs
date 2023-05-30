using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public int maxScores = 7;
    public Text highScoresText;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject highScoreEntryPrefab;
    private List<HighScore> highScores = new List<HighScore>();

    [System.Serializable]
    public class HighScore //Data structure for the higscores
    {
        public string playerName;
        public int score;
    }

    void Start()
    {
        LoadHighScores(); //load the highscores from prefs
        UpdateHighScoresText(); //update the UI based on load
    }

    void LoadHighScores() // load from prefs
    {
        for (int i = 0; i < maxScores; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName" + i);
            int score = PlayerPrefs.GetInt("PlayerScore" + i);
            highScores.Add(new HighScore { playerName = playerName, score = score });
        }
    }

    void SaveHighScores() // save scores to prefs
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, highScores[i].playerName);
            PlayerPrefs.SetInt("PlayerScore" + i, highScores[i].score);
        }
    }

    void UpdateHighScoresText() //update the UI to contain 7 best scores
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        GameObject HeaderObj = Instantiate(highScoreEntryPrefab, content.transform); //crete header prefab
        Text headerText = HeaderObj.GetComponent<Text>();
        headerText.text = "Player name | Player score"; // header row
        if(highScores != null){
        for (int i = 0; i < highScores.Count; i++) // show only 7 scores
        {
            if (!string.IsNullOrEmpty(highScores[i].playerName) && highScores[i].score != 0) //if theres scores show them else show empty
            {
                GameObject entryObj = Instantiate(highScoreEntryPrefab, content.transform);
                Text entryText = entryObj.GetComponent<Text>();
                entryText.text = highScores[i].playerName + " : " + highScores[i].score;
            }else{
                // nothing found
            }
        }
        }
    }

    public void AddHighScore(string playerName, int score) // add new score to prefs
    {
        highScores.Add(new HighScore { playerName = playerName, score = score });
        highScores.Sort((a, b) => b.score.CompareTo(a.score));

        if (highScores.Count > 7)
        {
            highScores.RemoveAt(7);
        }
        SaveHighScores();
        UpdateHighScoresText();
    }

    public List<HighScore> GetHighScores() //return highscores to diff scripts
    {
    return highScores;
    }

}