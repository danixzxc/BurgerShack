using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlot : MonoBehaviour
{
    private bool _hasBurger = false;
    [SerializeField]
    private GameObject _burger;

    public void AddBurger()
    {
        _hasBurger = true;
        _burger.SetActive(true);
    }

    public void RemoveBurger()
    {
        _hasBurger = false;
        _burger.SetActive(false);
    }

    public bool HasBurger()
    { 
        return _hasBurger;
    }
}
