using UnityEngine;

public class WormController : MonoBehaviour
{
    private CapsuleCollider2D colliderWorm;

    public int life;
    public GameObject range;

    void Start()
    {
        colliderWorm = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        colliderWorm.enabled = false;
        range.SetActive(false);

        Destroy(gameObject);
    }
}
