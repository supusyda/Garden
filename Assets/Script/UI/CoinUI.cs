using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text coinText;

    private void SetCoin(int coin) => coinText.text = coin.ToString();
    public void OnCoinChange(Component sender, object data)
    {
        int coin = data is int ? (int)data : 0;
        SetCoin(coin);
    }
}
