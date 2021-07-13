using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class EndSplash : MonoBehaviour
{
    public static int sceneNumber;
    public void Start()
    {
        if (sceneNumber == 0)
        {
            StartCoroutine(ToSplash2());
        }
        else if (sceneNumber == 1)
        {
            StartCoroutine(ToMainMenu());
        }
    }
    IEnumerator ToSplash2()
    {
        yield return new WaitForSeconds(2);
        sceneNumber = 1;
        SceneManager.LoadScene("Splash Screen 2");
    }
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(2);
        sceneNumber = 2;
        SceneManager.LoadScene("Main Menu");
    }
}
