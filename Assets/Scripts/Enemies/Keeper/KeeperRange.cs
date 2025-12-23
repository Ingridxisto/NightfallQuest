using UnityEngine;

public class KeeperRange : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<Animator>().Play("Attack", -1);
        }
    }
}
