using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI uitextCoins;

    public void UpDateTextCoins(string s)
    {
        uitextCoins.text = s;
    }

 
}
