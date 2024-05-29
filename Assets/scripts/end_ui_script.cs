using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class end_ui_script : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    private int points;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPoints"))
        {
            points = PlayerPrefs.GetInt("PlayerPoints");

            highScore = PlayerPrefs.GetInt("HighScore", 0);

            if (points > highScore)
            {
                PlayerPrefs.SetInt("HighScore", points);
                PlayerPrefs.Save();
            }
        }
        else
        {
            points = 0;
        }

        scoreText.text = "score " + points.ToString();

        if (highScore == 0)
        {
            highscoreText.text = "Highscore 0";
        }
        else
        {
            highscoreText.text = "Highscore " + highScore.ToString();
        }
    }
}
