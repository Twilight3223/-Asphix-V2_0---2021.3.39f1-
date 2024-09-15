using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript2 : MonoBehaviour
{
    public Sprite lleno;
    public Sprite dos;
    public Sprite uno;
    public Sprite vacio;

    private Rigidbody2D rb;
    public float _speed;
    public float _jumpSpeed;
    public bool _jump = true;
    public int _lifes = 3;
    public int gamelifes = 3;
    public GameObject bullet;
    public Transform gun;
    public bool flip = false;
    public TMP_Text lifesText;

    public Image _a;

    public GameObject Victory;
    public GameObject Defeat;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            float x = Input.GetAxisRaw("Horizontal");

            if (x == -1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                gun.localPosition = new Vector2(-0.21f, -0.042f);
                flip = true;

            }
            else if (x == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                flip = false;
                gun.localPosition = new Vector2(0.21f, -0.042f);


            }

            if (flip == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject B = Instantiate(bullet, gun.position, Quaternion.identity);
                    B.GetComponent<Bulletscript>()._speed = -3;
                }
            }
            else if (flip == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject B = Instantiate(bullet, gun.position, Quaternion.identity);
                    B.GetComponent<Bulletscript>()._speed = 3;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && _jump == true)
            {
                rb.AddForce(new Vector2(rb.velocity.x, _jumpSpeed), ForceMode2D.Impulse);
                _jump = false;
            }
            x *= _speed;
            rb.velocity = new Vector2(x, rb.velocity.y);
        }

        if (_lifes <= 0)
        {
            Defeat.SetActive(true);
        }


        if (_lifes == 3)
        {
            _a.sprite = lleno;
        }
        if (_lifes == 2)
        {
            _a.sprite = dos;
        }
        if (_lifes == 1)
        {
            _a.sprite = uno;
        }
        if (_lifes == 0)
        {
            _a.sprite = vacio;
        }
    }
    void OnCollisionEnter2D(Collision2D salto)
    {
        if (salto.transform.CompareTag("floor"))
        {
            _jump = true;
        }
        if (salto.transform.CompareTag("Hazard"))
        {
            _lifes--;
        }
        if (salto.transform.CompareTag("Death"))
        {
            _lifes -= 3;
            Defeat.SetActive(true);
            lifesText.text = "x " + gamelifes.ToString();
        }
        if (salto.transform.CompareTag("Enemy"))
        {
            _lifes--;
        }
        if (salto.transform.CompareTag("EnemyBullet"))
        {
            _lifes--;
        }
        if (salto.transform.CompareTag("Victory"))
        {
            Victory.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(2);
    }
}
