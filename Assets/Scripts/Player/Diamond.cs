using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.totalDiamonds++;

            AudioManager.instance.PlayCollect();
            
            Destroy(gameObject);
        }
    }
}
