using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public bool isjumping;

    public float speed;

    public float jump;

    private Rigidbody2D rig;

    private Animator anim;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Movement();

        Jump();
    }

    void Movement()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        transform.position += movement * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0f)
        {

            if (Input.GetAxis("Horizontal") > 0f)
            {

                anim.SetBool("walk", true);

                transform.eulerAngles = new Vector3(0f, 180f, 0f);

            }
            else
            {

                anim.SetBool("walk", false);

            }



        }



    }


    void Jump()
    {

        if (Input.GetButtonDown("Jump") && !isjumping)
        {

            rig.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameManager.access.Winner();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 6)
        {

            isjumping = false;

            anim.SetBool("jump", false);
        }
        if (collision.gameObject.layer == 7)
        {

            GameManager.access.GameOver();

            Destroy(gameObject);

        }
    }

       

       private void OnCollisionExit2D(Collision2D collision)
       {  
          if (collision.gameObject.layer == 6)
          {

              isjumping = true;

             anim.SetBool("jump", true);



            
          }
       }
}

































    