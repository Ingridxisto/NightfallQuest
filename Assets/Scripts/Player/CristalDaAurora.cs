using UnityEngine;

public class CristalDaAurora : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.CollectFragment();

            AudioManager.instance.PlayCollect();
            
            Destroy(gameObject);
        }
    }
}
