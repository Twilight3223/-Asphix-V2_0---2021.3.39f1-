using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroSorcerer : MonoBehaviour
{
    public int enemylifes;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemylifes <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            enemylifes--;
        }
    }
}
