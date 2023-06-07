using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float id;
    public float moveSpeed = 1.0f;

    private void Update()
    {
        float movement = ProcessInput();
        Move(movement);
    }

    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("movePlayer1");
                break;

                case 2:
                movement = Input.GetAxis("movePlayer2");
                break;
        }
        return movement;
    }

   private void Move(float movement)
    {
Vector2 valo = rb2d.velocity;
       valo.y = moveSpeed * movement;
        rb2d.velocity = valo;
    }
}
