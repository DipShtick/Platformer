using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed, smooth, jumpForce;
    Rigidbody2D rb;

    public Collider2D checker;
    public LayerMask groundLayer;
    Animator _anim;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    bool facingRight = true, grounded;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        _anim.SetBool("Running", x != 0);
        _anim.SetBool("Jumping", !grounded);

        Vector2 targetVelocity = new Vector2(x * speed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref targetVelocity, Time.deltaTime * smooth);
        
        if (x > 0 && !facingRight)
        {
            Flip();
        }
        else if (x < 0 && facingRight)
        {
            Flip();
        }

        grounded = checker.IsTouchingLayers(groundLayer);
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Star")
        {
            Destroy(col.gameObject);
            gameObject.tag = "PowerUp";
            gameObject.GetComponent<Renderer>().material.color = Color.green;

            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Player";
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void Flip()
    {
        facingRight = !facingRight;
        
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
