using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    public float jumpForce = 150.0f;
    public float speedFox = 1.0f;
    private float moveDirection;


    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animatorFox;

    private void Awake()
    {
        _animatorFox = GetComponent<Animator>(); //cacning animator
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2D.velocity = new Vector2(speedFox * moveDirection, _rigidbody2D.velocity.y);

        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }

    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animatorFox.SetFloat("speedFox", speedFox);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animatorFox.SetFloat("speedFox", speedFox);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            _animatorFox.SetFloat("speedFox", 0.0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _animatorFox.SetTrigger("jump");
            _animatorFox.SetBool("grounded", false);

        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            _animatorFox.SetBool("grounded", true);
            grounded = true;
        }

    }
}
