using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public void Explode()
    {
        GameManager.instance.SaveData();
        GameManager.instance.CompareScores();
        SceneManager.LoadScene("Main Menu");
    }
    public void WinLevel()
    {
        GameManager.instance.SaveData();
        GameManager.instance.CompareScores();
        SceneManager.LoadScene("Main Game");
    }
}
