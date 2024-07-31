using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Invader[] prefabs;

    public int rows;

    public int colums;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++) {

            float width = 1.0f * (this.colums - 1);

            float height = 1.0f * (this.rows - 1);
        }
    }
}
