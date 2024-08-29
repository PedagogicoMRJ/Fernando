using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioSource music;

    private void OntriggerEnter2D(Collider2D collision)
    {
        music.Play();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {

            this.gameObject.SetActive(false);
        }
    }

}