
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameLoop : MonoBehaviour
{
    public float restartDelay = 2f;
    private bool isGameOver = false;

    public void EndGame()
    {
        if (isGameOver) return;

        isGameOver = true;
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(restartDelay);

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
