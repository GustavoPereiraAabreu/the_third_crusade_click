using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReconquistaButton : MonoBehaviour
{
    [Header("Referências")]
    public Button button;                
    public TextMeshProUGUI custoText;  

    [Header("Configuração")]
    public int custoReconquista = 50;   
    private ClickerGame game;

    private void Start()
    {
        game = FindObjectOfType<ClickerGame>();

        if (button != null)
            button.onClick.AddListener(ReconquistarArea);

        AtualizarUI();
    }

    private void Update()
    {
     
        if (button != null && game != null)
            button.interactable = (game.score >= custoReconquista);
    }

    public void ReconquistarArea()
    {
        if (game != null && game.score >= custoReconquista)
        {
            game.score -= custoReconquista;
            AtualizarUI();
        }
    }

    public void AtualizarUI()
    {
        if (custoText != null)
            custoText.text = "Custa " + custoReconquista + " pontos";
    }
}