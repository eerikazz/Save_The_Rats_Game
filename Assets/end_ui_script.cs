using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end_ui_script : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPoints"))
        {
            points = PlayerPrefs.GetInt("PlayerPoints");
        }
        else
        {
            points = 0;
        }

        scoreText.text = "score " + points.ToString();
    }
}
