using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    
    public HealthBase healthBase;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill; //Estou adicionando esse void no Action (CallBack)
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;//Retira porque se nao fica registrado na memoria
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();//Pegando o Script do item que colidiu

        if(health != null)
        {
            health.Damage(damage); //Passando o Dano para o Script de quem colidiu
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Demage(int amount)
    {
        healthBase.Damage(amount);
        //Debug.Log("Damage");
    }

}
