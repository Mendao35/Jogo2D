using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //public Vector2 velocity;
    public Rigidbody2D myRigidBody;

    public HealthBase healthBase;

    public Animator animator;

    [Header("Setup")]
    public SOPlayer soPlayer;

    /*
    [Header("SpeedSetup")]
    public float speed;
    public float speedRun;
    public Vector2 friction = new Vector2(-.1f, 0);
    private float _currentSpeed;

    [Header("JumpSetup")]
    public float forceJump = 5f;

    [Header("AnimationPlayer")]
    public string boolRun = "Run";//Mesmo nome que esta no Animator
    public string triggerDeath = "Death";  
    public float playerSwipeDuration = .2f;*/


    /*[Header("AnimationSetup")]
    public float jumpScaler = 1.5f;
    public float animationDuration = .3f;*/


    private void Awake()
    {
        soPlayer._currentSpeed = soPlayer.speed;

        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        animator.SetTrigger(soPlayer.triggerDeath);
    }

    void Update()
    {
        HandleMoviment();
        HandleJump();
    }

    public void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            soPlayer._currentSpeed = soPlayer.speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            soPlayer._currentSpeed = soPlayer.speed;
            animator.speed = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);

            myRigidBody.velocity = new Vector2(-soPlayer._currentSpeed, myRigidBody.velocity.y);

            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, soPlayer.playerSwipeDuration);
                //myRigidBody.transform.localScale = new Vector3(-1, 1, 1);
            }


            animator.SetBool(soPlayer.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);

            myRigidBody.velocity = new Vector2(+soPlayer._currentSpeed, myRigidBody.velocity.y);
            
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, soPlayer.playerSwipeDuration);
                //myRigidBody.transform.localScale = new Vector3(1, 1, 1);
            }


            animator.SetBool(soPlayer.boolRun, true);
        }
        else
        {
            animator.SetBool(soPlayer.boolRun, false);
        }

        if(myRigidBody.velocity.x > 0)//Adicionar uma fricçao para parar o player quando vai para direita
        {
            myRigidBody.velocity -= soPlayer.friction; 
        }
        else if(myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += soPlayer.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * soPlayer.forceJump;
            //HandleJump();
        }           
    }

    private void HandleScaleJump()
    {
        //myRigidBody.transform.DOScaleY(jumpScaler, animationDuration).SetLoops(2, LoopType.Yoyo);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
