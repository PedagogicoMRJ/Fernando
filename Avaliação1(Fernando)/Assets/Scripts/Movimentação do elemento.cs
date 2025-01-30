using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rb;
      
    void Update()
    {
        MovementX();
        MovementY();
    }

    void MovementX()
    {

        Vector3 movementX = new Vector3(0f, Input.GetAxis("Vertical1"));

        transform.position += movementX * speed * Time.deltaTime;

    }

    void MovementY()
    {

        Vector3 movementY = new Vector3(Input.GetAxis("Horizontal1"), 0f);

        transform.position += movementY * speed * Time.deltaTime;

    }























}