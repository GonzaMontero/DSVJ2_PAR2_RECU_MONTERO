using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayRestart()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings and Credits");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
