using UnityEngine;
using System.Collections;
public class CheckIfObjectLeaves : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject returnText;
    [SerializeField] int timeOutsideY;
    private bool LeftScreen;

    private void LateUpdate()
    {
        if(!player.GetComponent<Renderer>().isVisible && LeftScreen == false)
        {
            StartCoroutine(ObjectReturnTimer());
            returnText.SetActive(true);
        }
        else if(player.GetComponent<Renderer>().isVisible && LeftScreen == true)
        {
            StopAllCoroutines();
            LeftScreen = false;
            returnText.SetActive(false);
        }
    }

    IEnumerator ObjectReturnTimer()
    {
        LeftScreen = true;
        yield return new WaitForSeconds(timeOutsideY);
        GameObject levelManager = GameObject.FindGameObjectWithTag("Level");
        levelManager.GetComponent<LevelChanger>().Explode();
    }
}
