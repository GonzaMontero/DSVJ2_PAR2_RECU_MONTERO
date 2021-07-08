public class GameManager : Singleton<GameManager>
{
    public struct PlayerData
    {
        public float fuel;
        public int currentLevel;
        public int playerScore;
    }
    public PlayerData data;
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        data.playerScore = 0;
        data.fuel = 100;
        data.currentLevel = 1;
    }
    public void SaveData()
    {
        player = FindObjectOfType<Player>();
        data.playerScore = player.matchData.score;
        data.currentLevel = player.matchData.level;
        data.fuel = player.matchData.fuel;
    }
    public void LoadData()
    {
        player = FindObjectOfType<Player>();
        player.matchData.fuel = data.fuel;
        player.matchData.level = data.currentLevel;
        player.matchData.score = data.playerScore;
    }
}
