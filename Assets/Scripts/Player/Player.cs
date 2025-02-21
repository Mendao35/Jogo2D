using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Vector2 velocity;
    public Rigidbody2D myRigidBody;
    public float speed;

    public float forceJump = 5f;

    public Vector2 friction = new Vector2(-.1f, 0);

    void Update()
    {
        HandleMoviment();
        HandleJump();
    }

    public void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(+speed, myRigidBody.velocity.y);
        }

        if(myRigidBody.velocity.x > 0)//Adicionar uma fricçao para parar o player quando vai para direita
        {
            myRigidBody.velocity -= friction; 
        }
        else if(myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * forceJump;
        }
           
    }
}
