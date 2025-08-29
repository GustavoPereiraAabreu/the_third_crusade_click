using UnityEngine;
using TMPro;

public class ClickerGame : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int Somack = 10;
    public int Subtraick = -10;
    public float Multiplicack = 2;
    public float Divideck = 2;

    public void upgradeSoma()
    {
        score += Somack;
        UpdateScoreText();
    }

    public void AddPoints()
    {
        score++;

    }

    public void UpdateScoreText()
    {
        scoreText.text = "Batalhas Vencidas: " + score;
    }

    public void Update()
    {
        UpdateScoreText();
    }
}
