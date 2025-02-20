using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .5f;
    public Ease ease = Ease.OutBack;//Ajuste de animaçao deixar mais fluido

    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (var b in buttons) //Desligar Butoes
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }
    private void ShowButtons() //Liga Botoes
    {
        for(int i = 0; i < buttons.Count ; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            //Vai fazer a escala, e vai botar um delay na escala gradativo
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }


}
