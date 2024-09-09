using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBurgerQueue : ClientQueue
{
    [SerializeField]
    private Transform _grabBurgerTransform;

    [SerializeField]
    private BurgerSlot _burgerSlot;
    public override Vector3 GetServicedClientTarget()
    {
        return _grabBurgerTransform.position;
    }
    public override Vector3 GetAvaialbleQueuePlace()
    {
        if (GetCount() == 1 && _burgerSlot.HasBurger())
        {
            return _grabBurgerTransform.position;
        }
        else
        {
            return base.GetAvaialbleQueuePlace();
        }
    }
}
