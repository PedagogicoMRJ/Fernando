using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceeship : MonoBehaviour
{
    public Laser laserPrefab;

    private bool laserActive;

    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            this.transform.position += Vector3.left * this.speed * Time.deltaTime;

        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            Shoot();

        }
    }


    private void Shoot()
    {

        if (!laserActive)
        {

            Laser laser = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);

            laser.destroyed += LaserDestroyed;
                
            laserActive = true;
        }
    }  
    private void LaserDestroyed()
    {

        laserActive = false;

    }
}