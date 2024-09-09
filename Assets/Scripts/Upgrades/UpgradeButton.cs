using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private UpgradeScriptableObject _data;
    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private TextMeshProUGUI _nextLevelUpgradeText;
    [SerializeField]
    private TextMeshProUGUI _priceText;
    [SerializeField]
    private MoneyManager _moneyManager;

    private PlayerMovementController _playerMovementController;
    private OvenZone _ovenZone;
    [SerializeField] 
    private CashZone _cashZone;

    private int _level;
    private float _value;
    private int _price;

    private void Start()
    {
        _level = 1;
        _price = _data.defaultPrice;
        _value = _data.defaultValue;
        ChangeDescription();
        _playerMovementController = FindObjectOfType<PlayerMovementController>();
        _ovenZone = FindObjectOfType<OvenZone>();
        switch (_data.type)
        {
            case Type.PlayerSpeed:
                _playerMovementController.speed = _value;
                break;
            case Type.BurgerSpeed:
                _ovenZone.loadingSpeed = _value;
                break;
            case Type.CashSpeed:
                _cashZone.loadingSpeed = _value;
                break;
        }
    }
    public void Upgrade()
    {
        if (_price <= _moneyManager.GetMoneyAmount())
        {
            _moneyManager.ChangeMoneyAmount(-_price);
            IncreaseValue();
            IncreasePrice();
            IncreaseLevel();
            ChangeDescription();
            if (_level == _data.maxLevel)
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }
    private void IncreaseValue()
    {
        _value += _data.increaseValue;
        switch (_data.type)
        {
            case Type.PlayerSpeed:
                _playerMovementController.speed = _value;
                break;
            case Type.BurgerSpeed:
                _ovenZone.loadingSpeed = _value;
                break;
            case Type.CashSpeed:
                _cashZone.loadingSpeed = _value;
                break;
        }
    }
    private void IncreasePrice()
    {
        _price += _data.priceIncrease;
    }
    private void IncreaseLevel()
    {
        _level++;
    }
    private void ChangeDescription()
    {
        _levelText.text = $"Level {_level}";
        _priceText.text = $"{_price}$";
        _nextLevelUpgradeText.text = $"+{_value}\n{_data.type}";
    }
}
