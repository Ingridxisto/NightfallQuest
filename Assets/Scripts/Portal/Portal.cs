using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Configuração")]
    public string nextSceneName;
    public int fragmentRequired;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        /// Só abre se o player coletou o fragmento desta fase
        if (GameManager.instance.fragmentsCollected >= fragmentRequired)
        {
            AudioManager.instance.PlayCollect();

            // Se for o último fragmento, vai para FinalScene
            if (fragmentRequired == GameManager.instance.totalFragmentsNeeded)
                SceneManager.LoadScene("FinalScene");
            else
                SceneManager.LoadScene(nextSceneName);
        }

    }
}
