using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score;
    public TMP_Text scoretxt;
    public TMP_Text highscoretxt;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "coin")
        {
            score++;
            Destroy(col.gameObject);
            scoretxt.text = score.ToString();

            Highscore();
        }
    }

    void Highscore()
    {
        if(score > PlayerPrefs.GetInt("SavedScore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoretxt.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Lastscore", score);
        }
    }
}
