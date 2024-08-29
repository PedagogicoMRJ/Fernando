using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;

    public int rows;

    public int columns;

    public float speed;

    private Vector3 direction = Vector2.right;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {

            float width = 1.0f * (this.columns - 1);

            float height = 1.0f * (this.rows - 1);

             Vector2 centering = new Vector2(-width / 2, -height / 2);

             Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 0.55f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {

                Invader invader = Instantiate(this.prefabs[row], this.transform);

                Vector3 position = rowPosition;

                position.x += col * 0.85f;
                
                invader.transform.localPosition = position;

            }
        }
    }

     private void Update()
     {
        this.transform.position += direction * this.speed * Time.deltaTime;

         Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);

         Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {

            if (!invader.gameObject.activeInHierarchy)
            {

                continue;
            }

            if (direction == Vector3.right && invader.position.x >= (rightEdge.x - 0.5f))
            {
                AdvancedRow();

            } else if (direction == Vector3.left && invader.position.x <= (leftEdge.x + 0.5f))
            {
                AdvancedRow();
            }
        }
     }
  
     private void AdvancedRow()
     {
        direction.x *= -1.0f;

        Vector3 position = this.transform.position;

        position.y -= 0.2f;
 
        this.transform.position = position;
     }
}