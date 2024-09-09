using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _moneyText;

    private int _money;

    private void Start()
    {
        _money = 0;
        _moneyText.text = $"{_money} $";
    }

    public void ChangeMoneyAmount(int value)
    {
        _money += value;
        _moneyText.text = $"{_money} $";
    }

    public int GetMoneyAmount()
    {
        return _money;
    }
}
