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
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Explode()
    {
        GameManager.instance.SaveData();
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
        player.GetComponent<Player>().matchData.level++;
        player.GetComponent<Player>().matchData.score += 100;
        GameManager.instance.SaveData();
        GameManager.instance.CompareScores();
        GameHolder.SetActive(false);
        EndGameHolder.SetActive(true);
        HighScoreText.text = "High Score: " + GameManager.instance.highScore.playerScore;
        ButtonText.text = "Next Level";
        GameManager.instance.ResetScores();
        VictoryLossIcons[0].SetActive(true);
        VictoryLossIcons[1].SetActive(false);
    }
}
