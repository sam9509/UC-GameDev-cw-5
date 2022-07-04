using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float jump;
    bool CanJump = false;
    public Animator anim;
    SpriteRenderer Sprite;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        jump = 5;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject.tag == "Ground")
        {
            CanJump = true;
            anim.SetBool("Jump", false);
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")

            Destroy(collision.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = rb.velocity;


        if (Input.GetAxis("Horizontal") > 0)
            Sprite.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            Sprite.flipX = true;


        if (CanJump && Input.GetKeyDown(KeyCode.Space))

        {
            temp.y = jump;
            CanJump = false;
            anim.SetBool("Jump", true);

        }


        temp.x = Input.GetAxis("Horizontal") * speed;

        rb.velocity = temp;

        
        if(rb.velocity.x != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

   
}
