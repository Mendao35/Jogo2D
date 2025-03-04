using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .5f;
    public Ease ease = Ease.OutBack;//Ajuste de animaçao deixar mais fluido

    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
        
    }
    public void Init()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From();//efeito de escala
    }


}
