using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    [Header("SpeedSetup")]
    public float speed;
    public float speedRun;
    public Vector2 friction = new Vector2(-.1f, 0);
    public float _currentSpeed;

    [Header("JumpSetup")]
    public float forceJump = 5f;

    [Header("AnimationPlayer")]
    public string boolRun = "Run";//Mesmo nome que esta no Animator
    public string triggerDeath = "Death";
    //public Animator animator;
    public float playerSwipeDuration = .2f;
}
