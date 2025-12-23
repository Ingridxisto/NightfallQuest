using UnityEngine;

public class KeeperController : MonoBehaviour
{
    private CapsuleCollider2D colliderKeeper;
    private Animator anim;
    private bool goRight;

    public int life;
    public float speed;

    public Transform a;
    public Transform b;
    public GameObject range;
    
    void Start()
    {
        colliderKeeper = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(life <= 0)
        {
            this.enabled = false;
            colliderKeeper.enabled = false;
            range.SetActive(false);
            anim.Play("Die", -1);
        }
        
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }

        if(goRight == true)
        {
            if(Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }

            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, b.position, speed * Time.deltaTime);
        }

        else
        {
            if(Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }

            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, a.position, speed * Time.deltaTime);
        }
    }
}
