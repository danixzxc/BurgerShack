using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSellZone : MonoBehaviour
{
    private bool _burgerQueueIsFull;
    private bool _sellQueueIsEmpty;
    [SerializeField]
    private GameObject _sellZone;
    public void SetBurgerQueueFullness(bool value)
    {
        _burgerQueueIsFull = value;
        CheckForSellZone();
    }
    public void SetSellQueueEmptyness(bool value)
    {
        _sellQueueIsEmpty = value;
        CheckForSellZone();
    }

    public bool IsSellZoneActive()
    {
        return (!_burgerQueueIsFull && !_sellQueueIsEmpty);
    }
    private void CheckForSellZone()
    {
        if (!_burgerQueueIsFull && !_sellQueueIsEmpty)
            _sellZone.SetActive(true);
        else
            _sellZone.SetActive(false);
    }


}
