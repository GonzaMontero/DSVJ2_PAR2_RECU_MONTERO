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
    private void Start()
    {
        data.currentLevel = 1;
    }
    public void FindData()
    {
        GetHighScore();
    }
    public void CompareScores()
    {
        if (highScore.playerScore < data.playerScore)
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
    public void ResetScores()
    {
        data.playerScore = 0;
        data.currentLevel = 1;
    }
}
