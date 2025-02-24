using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color colorFlash = Color.red;
    public Color colorOriginal = Color.white;
    public float duration = .3f;

   

    private void OnValidate()
    {
        spriteRenderers.Clear();//Para a lista nao acumular valores
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())//Vai percorrer todos os filhos do objeto
        {
            spriteRenderers.Add(child); // Vai adicionar a lista os filhos dos objetos que possuam SpriteRenderer
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            Flash();
        }*/
    }

    public void Flash()
    {      

        StartCoroutine(FlashCoroutine());        
    }

    private IEnumerator FlashCoroutine()
    {
        foreach (var s in spriteRenderers)//Pra cada Item que esta na minha lista
        {
            s.color = colorFlash;            
        }
        yield return new WaitForSeconds(duration);

        foreach (var s in spriteRenderers)//Pra cada Item que esta na minha lista
        {
            s.color = colorOriginal;
        }
        

    }

}
