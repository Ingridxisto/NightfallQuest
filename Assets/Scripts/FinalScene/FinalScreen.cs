using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public void BackToMenu()
    {
        GameManager.instance.ResetProgress();
        SceneManager.LoadScene(0);
    }
}
