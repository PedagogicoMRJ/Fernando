using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    WaitForSeconds threeSec;

    int maxHealth = 100;

    public bool isPlayable;

    int currentHealth;

    public HealthBar healthBar;

    public bool isPlayer1;

    bool isKnockback = false;

    bool isAttack = false;

    string attack = "None";

    public float speed;

    private Animator anim;

    private Rigidbody2D rig;

    float move;
  
    void Start()
    {

        threeSec = new WaitForSeconds(3);

        isPlayable = false;

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        anim = GetComponentInChildren<Animator>();

        rig = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {


        if (currentHealth <= 0)
        {

            anim.SetBool("Defeat", true);

            StartCoroutine("Ending");

            SceneManager.LoadScene(0);

        }
        else if (isKnockback)
        {

            anim.SetBool("Knockback", false);

            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {

                isKnockback = false;

            }
        }
            
        else if (isAttack)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {

                isAttack = false;

            }
        }
    }

    void Update()
    {
        Debug.Log(currentHealth);

        if (currentHealth>0)
        {
            if (!isPlayable)
            {

                isPlayable = healthBar.finishCountDown;

            }
            else
            {
                if (!isAttack && !isKnockback)
                {

                    Movement();

                    Attack();

                }

            }
        }
    }
     void Movement()
     {

        if (isPlayer1)
        {

            move = Input.GetAxis("Horizontal1");

        }
        else
        {

            move = Input.GetAxis("Horizontal2");

        }

        rig.velocity = new Vector2(move * speed, 0.0f);

        anim.SetFloat("Walk", move);

     }

    void Attack()
    {
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                attack = "LightPunch";
            }

            else if (Input.GetKeyDown(KeyCode.W))
            {

                attack = "HeavyPunch";

            }

            else if (Input.GetKeyDown(KeyCode.E))
            {

                attack = "LightKick";

            }

            else if (Input.GetKeyDown(KeyCode.R))
            {

                attack = "Heavykick";

            }
            else
            {

                attack = "None";

            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                attack = "LightPunch";
            }

            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {

                attack = "Heavypunch";

            }

            else if (Input.GetKeyDown(KeyCode.Keypad1))
            {

                attack = "LightKick";

            }

            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {

                attack = "HeavyKick";

            }
            else
            {

                attack = "None";

            }

        }

        if (attack != "None")
        {

            move = 0;

            rig.velocity = new Vector2(move * speed, 0.0f);

            anim.SetFloat("Walk", move);

            anim.SetTrigger(attack);

            isAttack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        move = 0;

        rig.velocity = new Vector2(0.0f, 0.0f);

        anim.SetFloat("Walk", move);

        if (collision.gameObject.layer == 3)
        {
            anim.SetBool("Knockback", true);

            currentHealth -= 10;

            if (currentHealth > 0) { 
                healthBar.SetHealth(currentHealth);
                anim.SetBool("Knockback", true);
                if (isPlayer1)
                {

                    rig.velocity = new Vector2(speed * (-1), 0.0f);

                }
                else
                {

                    rig.velocity = new Vector2(speed * (-1), 0.0f);

                }
                isKnockback = true;
            }
        }
    }
    IEnumerator Ending()
    {

        yield return threeSec;

        anim.SetBool("Defeat", false);

        SceneManager.LoadScene(0);

    }
}

