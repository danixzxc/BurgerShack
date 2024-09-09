using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCashQueue : ClientQueue
{
    [SerializeField]
    private ClientBurgerQueue _burgerQueue;

    public override Vector3 GetServicedClientTarget()
    {
        return _burgerQueue.GetAvaialbleQueuePlace();
    }

    
}
