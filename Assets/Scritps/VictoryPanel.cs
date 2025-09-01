using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public GameObject winPanel;

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void ShowVictory()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
        Debug.Log("Vitória! Área reconquistada!");
    }
}
