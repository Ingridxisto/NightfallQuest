using UnityEngine;

public class KeeperAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.playerLife--;
        }
    }
}
