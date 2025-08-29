using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("Pontua��o")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("�reas e Vit�ria")]
    public Button reconquistarButton; // bot�o para reconquistar �rea
    public int custoReconquista = 50; // custo inicial para reconquistar
    private int areasReconquistadas = 0;
    public GameObject winPanel; // painel de vit�ria

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateScoreText();
        CheckReconquistaDisponivel(); // garante que o bot�o j� aparece certo
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
            // bot�o sempre aparece
            reconquistarButton.gameObject.SetActive(true);

            // fica interativo s� se tiver pontos suficientes
            reconquistarButton.interactable = (score >= custoReconquista);
        }
        else
        {
            // some quando o jogo j� foi vencido
            reconquistarButton.gameObject.SetActive(false);
        }
    }

    public void ReconquistarArea()
    {
        if (score >= custoReconquista)
        {
            score -= custoReconquista;
            areasReconquistadas++;

            custoReconquista *= 2; // pr�xima �rea fica mais cara
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

        Debug.Log("Vit�ria! Voc� venceu a Terceira Cruzada!");
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Batalhas Vencidas: " + score;
    }
}