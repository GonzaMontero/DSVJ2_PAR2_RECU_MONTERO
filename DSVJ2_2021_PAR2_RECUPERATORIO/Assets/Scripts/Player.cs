using UnityEngine;

public class Player : MonoBehaviour
{
    public struct MatchData
    {
        public int level;
        public int score;
    }
    public MatchData matchData;

    public int GetLevel()
    {
        return matchData.level;
    }
    public int GetScore()
    {
        return matchData.score;
    }
}
