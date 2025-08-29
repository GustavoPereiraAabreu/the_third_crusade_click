using UnityEngine;
using TMPro;
using UnityEngine.UI; // Para Button

public class Upgradde : MonoBehaviour
{
    [Header("Pontuação")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Upgrades")]
    public int Somack = 10;
    public int Subtraick = -10;
    public float Multiplicack = 2;
    public float Divideck = 2;

    [Header("Áreas e Vitória")]
    public Button reconquistarButton;
    public TextMeshProUGUI areaText; 
    public int custoReconquista = 50;
    private int areasReconquistadas = 0;
    public GameObject winPanel;

    private void Start()
    {
        if (reconquistarButton != null)
        {
            reconquistarButton.gameObject.SetActive(false);
            reconquistarButton.onClick.AddListener(ReconquistarArea);
        }

        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateScoreText();
        UpdateAreaText();
    }

    public void upgradeSoma()
    {
        score += Somack;
        UpdateScoreText();
    }

    public void AddPoints()
    {
        score++;
        UpdateScoreText();
        CheckReconquistaDisponivel();
    }

    public void CheckReconquistaDisponivel()
    {
        
        if (score >= custoReconquista && areasReconquistadas < 2)
        {
            reconquistarButton.gameObject.SetActive(true);
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
            score -= custoReconquista; // gasta pontos para reconquistar
            areasReconquistadas++;
            UpdateAreaText();
            UpdateScoreText();

            // aumenta o custo da próxima reconquista
            custoReconquista *= 2;

            // verifica vitória
            if (areasReconquistadas >= 2)
            {
                Vitoria();
            }
            else
            {
                reconquistarButton.gameObject.SetActive(false);
            }
        }
    }

    public void Vitoria()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true); // mostra painel de vitória
        }
        Debug.Log("Você ganhou a Terceira Cruzada!");
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Batalhas Vencidas: " + score;
    }

    public void UpdateAreaText()
    {
        if (areaText != null)
            areaText.text = "Áreas Reconquistadas: " + areasReconquistadas;
    }
}
