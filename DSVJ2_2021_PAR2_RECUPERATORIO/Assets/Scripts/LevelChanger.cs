using UnityEngine;
using TMPro;

public class LevelChanger : MonoBehaviour
{
    [Header("Level End Holder")]
    [SerializeField] GameObject GameHolder;
    [SerializeField] GameObject EndGameHolder;
    [SerializeField] TextMeshProUGUI ButtonText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] GameObject[] VictoryLossIcons;

    public void Explode()
    {
        GameManager.instance.CompareScores();
        GameHolder.SetActive(false);
        EndGameHolder.SetActive(true);
        ButtonText.text = "Retry";
        HighScoreText.text = "High Score: " + GameManager.instance.highScore.playerScore;
        GameManager.instance.ResetScores();
        VictoryLossIcons[0].SetActive(false);
        VictoryLossIcons[1].SetActive(true);
    }
    public void WinLevel()
    {
        GameManager.instance.data.playerScore += 100;
        GameManager.instance.data.currentLevel++;
        GameManager.instance.CompareScores();
        GameHolder.SetActive(false);
        EndGameHolder.SetActive(true);
        HighScoreText.text = "High Score: " + GameManager.instance.highScore.playerScore;
        ButtonText.text = "Next Level";
        VictoryLossIcons[0].SetActive(true);
        VictoryLossIcons[1].SetActive(false);
    }
}
