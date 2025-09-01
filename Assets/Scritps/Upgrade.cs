using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("Pontuação")]
    public int score = 300;
    public TextMeshProUGUI scoreText;

    [Header("Áreas e Vitória")]
    public Button reconquistarButton;
    public int custoReconquista = 300;
    private int areasReconquistadas = 0;
    public GameObject winPanel;

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateScoreText();
        CheckReconquistaDisponivel();
    }

    public void AddPoints()
    {
        score++;
        UpdateScoreText();
        CheckReconquistaDisponivel();
    }

    public void CheckReconquistaDisponivel()
    {
        if (areasReconquistadas < 2)
        {
      
            reconquistarButton.gameObject.SetActive(true);

       
            reconquistarButton.interactable = (score >= custoReconquista);
        }
        else
        {
    
            reconquistarButton.gameObject.SetActive(false);
        }
    }

    public void ReconquistarArea()
    {
        if (score >= custoReconquista)
        {
            score -= custoReconquista;
            areasReconquistadas++;

            custoReconquista *= 2;
            UpdateScoreText();
            CheckReconquistaDisponivel();

        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Reconquiste Jerusalem: " + score;
    }
}