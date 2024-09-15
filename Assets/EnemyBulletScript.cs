using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right * -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("floor"))
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (collision.transform.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
