using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

    public GUIText highScoreGUIText;
    private int score;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        highScoreGUIText.text = "Score : " + score.ToString();
    }

    private void Initialize()
    {
        score = 0;
    }

    public void AddPoint(int point)
    {
        score += point;
    }
}
