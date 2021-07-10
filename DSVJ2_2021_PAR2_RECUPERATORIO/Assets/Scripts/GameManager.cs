using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    public struct PlayerData
    {
        public int currentLevel;
        public int playerScore;
    }
    public PlayerData data;
    public PlayerData highScore;
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        data.playerScore = 0;
        data.currentLevel = 1;
        GetHighScore();
    }
    public void SaveData()
    {
        player = FindObjectOfType<Player>();
        data.playerScore = player.matchData.score;
        data.currentLevel = player.matchData.level;
    }
    public void LoadData()
    {
        player = FindObjectOfType<Player>();
        player.matchData.level = data.currentLevel;
        player.matchData.score = data.playerScore;
    }
    public void CompareScores()
    {
        if (highScore.playerScore < player.matchData.score)
        {
            highScore = data;
            PlayerPrefs.SetInt("Score", highScore.playerScore);
            PlayerPrefs.SetInt("Level Reached", highScore.currentLevel);
        }
    }
    public void GetHighScore()
    {
        highScore.playerScore = PlayerPrefs.GetInt("Score");
        highScore.currentLevel = PlayerPrefs.GetInt("Level Reached");
    }
}
