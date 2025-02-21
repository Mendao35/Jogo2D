using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();//Pegando o Script do item que colidiu

        if(health != null)
        {
            health.Damage(damage); //Passando o Dano para o Script de quem colidiu
        }
    }

}
