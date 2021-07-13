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
    private GameObject player;
    public void FindData()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Player startingData = player.GetComponent<Player>();
        data.playerScore = 0;
        data.currentLevel = 1;
        GetHighScore();
    }
    public void SaveData()
    {
        Player savedData = player.GetComponent<Player>();
        data.playerScore = savedData.GetScore();
        data.currentLevel = savedData.GetLevel();
    }
    public void LoadData()
    {
        Player loadedData = player.GetComponent<Player>();
        loadedData.matchData.level = data.currentLevel;
        loadedData.matchData.score = data.playerScore;
    }
    public void CompareScores()
    {
        Player compareData = player.GetComponent<Player>();
        if (highScore.playerScore < compareData.matchData.score)
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
