
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishGame : MonoBehaviour
{
    public float restartDelay = 1f;
    private bool finished = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected: " + other.name);

        if (finished)
            return;

        if (!other.CompareTag("Player"))
        {
            Debug.Log("This object is not tagged Player.");
            return;
        }

        finished = true;
        Debug.Log("FINISH! Restarting scene...");
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(restartDelay);

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex < 0)
        {
            Debug.LogError(
                "Scene is not in Build Settings. Add the scene first."
            );
            yield break;
        }

        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
