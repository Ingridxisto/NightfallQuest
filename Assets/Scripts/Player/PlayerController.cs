using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //Variáveis Privadas
    private Rigidbody2D rb;
    private Animator anim;
    private CapsuleCollider2D colliderPlayer;
    private float moveX;
    private bool isDead = false;
    private bool isRunning = false;

    // Variáveis de Escalada
    private bool isClimbing = false;
    public float climbSpeed = 3f;

    // Variáveis públicas
    public float speed;
    public int addJumps;
    public bool isGrounded;
    public float jumpForce;

    public TextMeshProUGUI textDiamond;
    public TextMeshProUGUI textLife;
    public TextMeshProUGUI textCristal;
    public string levelName;
    public GameObject canvasGameOver;
    public GameObject canvasPause;
    public bool isPause;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colliderPlayer = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (GameManager.instance == null) return;

        textDiamond.text = GameManager.instance.totalDiamonds.ToString();
        textLife.text = GameManager.instance.playerLife.ToString();
        textCristal.text = GameManager.instance.fragmentsCollected + "/" + GameManager.instance.totalFragmentsNeeded;

        if (GameManager.instance.playerLife <= 0 && !isDead)
        {
            Die();
        }

        if (!isDead)
        {
            Attack();
        }

        if (Input.GetButtonDown("Cancel") && !isDead)
        {
            PauseScreen();
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.velocity = new Vector2(0, Input.GetAxisRaw("Vertical") * climbSpeed);
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
            return;
        }

        Move();

        if (isGrounded)
        {
            addJumps = 2;
            if (Input.GetButtonDown("Jump")) Jump();
        }
        else if (Input.GetButtonDown("Jump") && addJumps > 0)
        {
            addJumps--;
            Jump();
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (moveX != 0)
        {
            if(!isRunning)
            {
                AudioManager.instance.PlayRun();
                isRunning = true;
            }

            anim.SetBool("isRun", true);
            transform.eulerAngles = moveX > 0 
                ? new Vector3(0f, 0f, 0f)
                : new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("isRun", false);
            isRunning = false;
        }    
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        anim.SetBool("isJump", true);

        AudioManager.instance.PlayJump();
    }

    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.Play("Attack", -1);
            AudioManager.instance.PlayAttack();
        }
    }

    void Die()
    {
        isDead = true;

        AudioManager.instance.PlayDeath();

        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        colliderPlayer.enabled = false;
    

        anim.Play("Die");

        canvasGameOver.SetActive(true);
        Time.timeScale = 0;
    }


    void PauseScreen()
    {
        if(isPause)
        {
            isPause = false;
            Time.timeScale = 1;
            canvasPause.SetActive(false);
        }
        else
        {
            isPause = true;
            Time.timeScale = 0;
            canvasPause.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1;
        canvasPause.SetActive(false);
    }

    public void BackMainMenu()
    {
        Time.timeScale = 1;

        // Reset básico
        GameManager.instance.playerLife = 5;
        GameManager.instance.totalDiamonds = 0;
        GameManager.instance.fragmentsCollected = 0;

        SceneManager.LoadScene(0);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("isJump", false);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ClimbWall"))
        {
            isClimbing = true;
            rb.gravityScale = 0; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ClimbWall"))
        {
            isClimbing = false;
            rb.gravityScale = 3; 
        }
    }
}
