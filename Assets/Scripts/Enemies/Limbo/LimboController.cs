using UnityEngine;

public class LimboController : MonoBehaviour
{
    public string playerTag = "Player";
    public float bounceForce = 7f;

    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && !isDead)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            float contactYNormal = collision.contacts[0].normal.y;

            // Player caiu em cima do Limbo
            if (contactYNormal < -0.9f)
            {
                Die(playerRb);
            }
            else
            {
                // Player bateu de lado ou por baixo → perde vida
                GameManager.instance.playerLife--;
            }
        }
    }

    void Die(Rigidbody2D playerRb)
    {
        isDead = true;
        BouncePlayer(playerRb);
        Destroy(gameObject);
    }

    void BouncePlayer(Rigidbody2D playerRb)
    {
        if (playerRb != null)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
