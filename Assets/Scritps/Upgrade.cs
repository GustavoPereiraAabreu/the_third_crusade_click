using UnityEngine;
using TMPro;
using UnityEngine.UI; // Para Button

public class Upgradde : MonoBehaviour
{
    [Header("Pontua��o")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Upgrades")]
    public int Somack = 10;
    public int Subtraick = -10;
    public float Multiplicack = 2;
    public float Divideck = 2;

    [Header("�reas e Vit�ria")]
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

            // aumenta o custo da pr�xima reconquista
            custoReconquista *= 2;

            // verifica vit�ria
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
            winPanel.SetActive(true); // mostra painel de vit�ria
        }
        Debug.Log("Voc� ganhou a Terceira Cruzada!");
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Batalhas Vencidas: " + score;
    }

    public void UpdateAreaText()
    {
        if (areaText != null)
            areaText.text = "�reas Reconquistadas: " + areasReconquistadas;
    }
}
