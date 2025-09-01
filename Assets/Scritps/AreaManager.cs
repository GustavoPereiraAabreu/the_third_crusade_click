using UnityEngine;
using UnityEngine.UI;

public class AreaManager : MonoBehaviour
{
    [Header("Dependências")]
    [SerializeField] private ClickerGame clickerGame;

    [Header("Configuração da Área")]
    public int requiredClicks = 50;    
    public Button areaButton;          

    private void Reset()
    {
        if (areaButton == null) areaButton = GetComponent<Button>();
    }

    private void Awake()
    {
        if (areaButton == null) areaButton = GetComponent<Button>();
    }

    private void Update()
    {
        if (clickerGame == null || areaButton == null) return;
   
        areaButton.interactable = (clickerGame.score >= requiredClicks);
    }


    public void TryReconquer()
    {
        if (clickerGame == null || areaButton == null) return;
        if (clickerGame.score >= requiredClicks)
        {
            clickerGame.score -= requiredClicks;
            clickerGame.UpdateScoreText();
            areaButton.interactable = false;
        }
    }
}