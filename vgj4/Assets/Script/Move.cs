using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Move : SerializedMonoBehaviour
{
    [SerializeField]
    private float speed=1;

    private Rigidbody2D rb;
    private Animator animator;

    private bool canJump=false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis(gameObject.name + "Move") > 0)
        {
            rb.velocity = new Vector2(canJump ? speed : speed / 2, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isWalk", true);
        }
        else if (Input.GetAxis(gameObject.name + "Move") < 0)
        {
            rb.velocity = new Vector2(canJump ? -speed : -speed / 2, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isWalk", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isWalk", false);
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.03f, 0.1f));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.97f, 0.83f));

        var pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        rb.position = pos;

        if (Input.GetButtonDown(gameObject.name + "Jump"))
        {
            rb.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
