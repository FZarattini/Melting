using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    private int score;


    public void ScoreCounterText (GameObject canvas)
    {
        canvas.GetComponent<Text>().text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score) {
        this.score += score;
    }
}
