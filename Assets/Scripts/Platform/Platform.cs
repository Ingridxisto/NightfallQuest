using UnityEngine;

public class Platform : MonoBehaviour
{
    private TargetJoint2D target;
    private BoxCollider2D boxColl;
    public Transform pivot;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();

        // Garante que começa presa
        target.enabled = true;
        boxColl.isTrigger = false;

        transform.position = pivot.position;
    }

    void PlatformDown()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(PlatformDown), 0.8f);
        }
    }
}
