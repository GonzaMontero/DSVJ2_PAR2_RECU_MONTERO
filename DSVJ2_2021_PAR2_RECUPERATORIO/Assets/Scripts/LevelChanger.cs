using UnityEngine;
using TMPro;

public class LevelChanger : MonoBehaviour
{
    [Header("Level End Holder")]
    [SerializeField] GameObject GameHolder;
    [SerializeField] GameObject EndGameHolder;
    [SerializeField] TextMeshProUGUI ButtonText;
    [SerializeField] GameObject[] VictoryLossIcons;

    public void Explode()
    {
        GameManager.instance.SaveData();
        GameManager.instance.CompareScores();
        GameHolder.SetActive(false);
        EndGameHolder.SetActive(true);
        ButtonText.text = "Retry";
        GameManager.instance.ResetScores();
        VictoryLossIcons[0].SetActive(false);
        VictoryLossIcons[1].SetActive(true);
    }
    public void WinLevel()
    {
        GameManager.instance.SaveData();
        GameManager.instance.CompareScores();
        GameHolder.SetActive(false);
        EndGameHolder.SetActive(true);
        ButtonText.text = "Next Level";
        GameManager.instance.ResetScores();
        VictoryLossIcons[0].SetActive(true);
        VictoryLossIcons[1].SetActive(false);
    }
}
