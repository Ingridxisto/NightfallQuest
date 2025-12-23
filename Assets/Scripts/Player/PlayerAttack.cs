using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Keeper"))
        {
            collision.GetComponent<KeeperController>().life--;
        }

        if(collision.CompareTag("Worm"))
        {
            collision.GetComponent<WormController>().life--;
        }   
    }
}
