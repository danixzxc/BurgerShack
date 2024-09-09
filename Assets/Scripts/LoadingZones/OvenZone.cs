using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenZone : LoadingZone
{
    [SerializeField]
    private BurgerSlot _burgerSlot;

    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<BurgerSlot>().HasBurger())
        {
            base.OnTriggerEnter(other);
            _burgerSlot.AddBurger();
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        _burgerSlot.RemoveBurger();
    }
    protected override void LoadingCompleted(Collider player)
    {
        base.LoadingCompleted(player);
        _burgerSlot.RemoveBurger();
        player.GetComponent<BurgerSlot>().AddBurger();

    }
}
