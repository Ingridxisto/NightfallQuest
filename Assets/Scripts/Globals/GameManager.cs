using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Status")]
    public int playerLife = 5;

    [Header("Collectables")]
    public int totalDiamonds = 0;

    [Header("Aurora Crystal Fragments")]
    public int fragmentsCollected = 0;
    public int totalFragmentsNeeded = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o GameManager entre cenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicatas
        }
    }

    public void CollectFragment()
    {
        fragmentsCollected++;

        if (fragmentsCollected >= totalFragmentsNeeded)
        {
            LoadFinalScene();
        }
    }

    private void LoadFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void ResetProgress()
    {
        fragmentsCollected = 0;
        playerLife = 5;
        totalDiamonds = 0;
    }
}
