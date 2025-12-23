using UnityEngine;

public class WormAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.playerLife--;
        }
    }
}
