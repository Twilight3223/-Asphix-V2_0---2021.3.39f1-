using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bala;
    public int _speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(_speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("floor"))
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);
        }
    }

}
