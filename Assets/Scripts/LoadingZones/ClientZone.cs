using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientZone : MonoBehaviour
{
    [SerializeField]
    private ActivateSellZone _activateSellZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Client>() != null)
        {
            _activateSellZone.SetSellQueueEmptyness(false);
        }
    }

}
