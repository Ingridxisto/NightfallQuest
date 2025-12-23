using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject canvasGameOver;

    public void Show()
    {
        canvasGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;

        GameManager.instance.playerLife = 5;
        GameManager.instance.totalDiamonds = 0;
        GameManager.instance.fragmentsCollected = 0;

        SceneManager.LoadScene(1);
    }

    public void BackMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
