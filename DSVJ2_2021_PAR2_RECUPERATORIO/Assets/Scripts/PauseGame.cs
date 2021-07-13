using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject[] playToMenuButtons;

    public void StartPause()
    {
        Time.timeScale = 0;
        playToMenuButtons[0].SetActive(true);
        playToMenuButtons[1].SetActive(true);
    }

    public void ResumeGame()
    {
        playToMenuButtons[0].SetActive(false);
        playToMenuButtons[1].SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GameManager.instance.SaveData();
    }
}
