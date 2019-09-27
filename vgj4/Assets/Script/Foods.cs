using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Foods : SerializedMonoBehaviour
{
    [SerializeField]
    private  float size;

    [SerializeField]
    private  int score;

    private Rigidbody2D rb;
    private new SpriteRenderer renderer;
    private float grouth;
    private bool hitGround;
    private Color transparentColor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(0, 0, 1);
        transparentColor = new Color(0, 0, 0, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(size, size, 1), Time.deltaTime * 1);

        if (transform.localScale.x >= size - 0.1f)
        {
            rb.simulated = true;
        }

        if (hitGround)
        {
            renderer.color -= transparentColor;
            if (renderer.color.a <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            hitGround = true;
            rb.AddForce(Vector2.up*3, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManagerScript>().LimitTime <= 0) return;

        if (collision.tag == "Basket")
        {
            var _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

            switch (this.gameObject.tag)
            {
                case "Ebi":
                    if (collision.gameObject.name == "AkaneBasket")
                    {
                        _scoreManager.AddScore(score);
                    }
                    break;
                case "ChocoMint":
                    if (collision.gameObject.name == "AoiBasket")
                    {
                        _scoreManager.AddScore(score);
                    }
                    break;
            }

            Destroy(gameObject);
        }
    }
}
