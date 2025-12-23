using UnityEngine;

public class Life : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.playerLife++;

            AudioManager.instance.PlayCollect();
        
            Destroy(gameObject);
        }
    }
}
