using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public int maxScores = 10;
    public Text highScoresText;

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject highScoreEntryPrefab;

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
        UpdateHighScoresText();
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

    void UpdateHighScoresText()
    {
        // Clear existing content
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        GameObject HeaderObj = Instantiate(highScoreEntryPrefab, content.transform);
        Text headerText = HeaderObj.GetComponent<Text>();
        headerText.text = "Player name | Player score";

        // Create new content
        if(highScores != null){
        for (int i = 0; i < highScores.Count; i++)
        {
            if (!string.IsNullOrEmpty(highScores[i].playerName) && highScores[i].score != 0)
            {
                GameObject entryObj = Instantiate(highScoreEntryPrefab, content.transform);
                Text entryText = entryObj.GetComponent<Text>();
                entryText.text = highScores[i].playerName + ": " + highScores[i].score;
            }
        }
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
        UpdateHighScoresText();
    }


    public List<HighScoreEntry> GetHighScores()
    {
    return highScores;
    }

}