using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("Pontuação")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Áreas e Vitória")]
    public Button reconquistarButton; // botão para reconquistar área
    public int custoReconquista = 50; // custo inicial para reconquistar
    private int areasReconquistadas = 0;
    public GameObject winPanel; // painel de vitória

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateScoreText();
        CheckReconquistaDisponivel(); // garante que o botão já aparece certo
    }

    public void AddPoints()
    {
        score++;
        UpdateScoreText();
        CheckReconquistaDisponivel();
    }

    void CheckReconquistaDisponivel()
    {
        if (areasReconquistadas < 2)
        {
            // botão sempre aparece
            reconquistarButton.gameObject.SetActive(true);

            // fica interativo só se tiver pontos suficientes
            reconquistarButton.interactable = (score >= custoReconquista);
        }
        else
        {
            // some quando o jogo já foi vencido
            reconquistarButton.gameObject.SetActive(false);
        }
    }

    public void ReconquistarArea()
    {
        if (score >= custoReconquista)
        {
            score -= custoReconquista;
            areasReconquistadas++;

            custoReconquista *= 2; // próxima área fica mais cara
            UpdateScoreText();
            CheckReconquistaDisponivel();

            if (areasReconquistadas >= 2)
            {
                Vitoria();
            }
        }
    }

    void Vitoria()
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        Debug.Log("Vitória! Você venceu a Terceira Cruzada!");
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Batalhas Vencidas: " + score;
    }
}