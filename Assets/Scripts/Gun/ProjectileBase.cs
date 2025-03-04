using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;

    public float timeToDestroy = 2f;

    public float side = 1;

    public int demageAmount = 1;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();// se colidir com objeto que tenha esse componemnte
        
        if(enemy != null)
        {
            enemy.Demage(demageAmount);
            Destroy(gameObject);//Quando Bater no inimigo vai destruir o projetile
        }
    }
}
