using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity;

    public Transform groundCheck;
    public LayerMask groundMask;

    public bool isGrpounded;

    public float radio;

    public GameObject drop;

    public int enemylifes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        if (Overlap() == false)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            velocity *= -1;
        }

        if (enemylifes <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    bool Overlap()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, radio, groundMask))
            return true;
        return false;
    }
    private void OnDestroy()
    {
        Instantiate(drop, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            enemylifes--;
        }
    }
}
