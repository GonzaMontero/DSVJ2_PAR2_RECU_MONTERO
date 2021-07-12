using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject creditsCanvas;
    public void GoToCredits()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    public void GoToMenu()
    {
        mainMenuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }
}
